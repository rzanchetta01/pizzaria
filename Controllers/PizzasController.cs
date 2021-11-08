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
        private readonly AvaliacaoService avaliacaoService;

        public PizzasController(PizzaService ps, AvaliacaoService avaliacaoService)
        {
            this.ps = ps;
            this.avaliacaoService = avaliacaoService;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await ps.GetPizzas();
        }
        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            return await ps.GetPizza(id);
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Pizza>> PutPizza(int id, Pizza pizza)
        {           
            return await ps.PutPizza(id, pizza);
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
           return await ps.PostPizza(pizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePizza(int id)
        {
            return await ps.DeletePizza(id);
        }
    }
}
