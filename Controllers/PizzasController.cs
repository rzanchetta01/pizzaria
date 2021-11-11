using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Model;
using Pizzaria.Services;

namespace Pizzaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaService ps;

        public PizzasController(PizzaService ps)
        {
            this.ps = ps;          
        }

        // GET: api/Pizzas
        [HttpGet("All/")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await ps.GetPizzas();
        }
        // GET: api/Pizzas/5
        [HttpGet("One/{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await ValidarId(id);
            return pizza.Value == null ? pizza.Result : Ok(pizza.Value);
            
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Req/{id}")]
        public async Task<ActionResult<Pizza>> PutPizza(int id, Pizza pizza)
        {
            if (pizza.Nome == null || pizza.QntFatias <= 0 || pizza.Preco <= 0.0)
            {
                return BadRequest("Parametros invalido");
            }

           pizza.Id = id;
           return await ps.PutPizza(id, pizza);
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Req")]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            var pizzas = await ps.GetPizzas();

            if (pizza.Nome == null || pizza.QntFatias <= 0 || pizza.Preco <= 0.0)
            {
                return BadRequest("Parametros invalido");
            }

            foreach (var e in pizzas.Value)
            {
                if(e.Nome == pizza.Nome || pizza.Nome == null)
                {
                    return BadRequest("Ja existe uma pizza com esse nome");
                }
            }

           return Ok(await ps.PostPizza(pizza));
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("Req/{id}")]
        public async Task<ActionResult<string>> DeletePizza(int id)
        {
            var pizza = await ValidarId(id);

            if(pizza.Value == null)
            {
                return BadRequest(pizza.Result);
            }
            return Ok(await ps.DeletePizza(id));
        }

        private async Task<ActionResult<Pizza>> ValidarId(int id)
        {
            try
            {
                var verify = await ps.GetPizza(id);

                if (verify == null)
                {
                    return BadRequest("id não encontrado");
                }

                return verify;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
