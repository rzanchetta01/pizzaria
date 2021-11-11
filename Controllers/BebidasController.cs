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
using Pizzaria.Validations;

namespace Pizzaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidasController : ControllerBase
    {
        private readonly BebidaService bs;

        public BebidasController(BebidaService bs)
        {
            this.bs = bs;
        }

        // GET: api/Bebidas
        [HttpGet("All/")]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await bs.GetBebidas();
        }

        // GET: api/Bebidas/5
        [HttpGet("One/{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            return await bs.GetBebida(id);
        }

        // PUT: api/Bebidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Req/{id}")]
        public async Task<ActionResult<Bebida>> PutBebida(int id, Bebida bebida)
        {
            var validado = new BebidasValidations().Validate(bebida);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await bs.PutBebida(id, bebida);            
        }

        // POST: api/Bebidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Req/")]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            var validado = new BebidasValidations().Validate(bebida);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await bs.PostPBebida(bebida);
        }

        // DELETE: api/Bebidas/5
        [HttpDelete("Req/{id}")]
        public async Task<ActionResult<string>> DeleteBebida(int id)
        {
            return await bs.DeleteBebida(id);
        }
    }
}
