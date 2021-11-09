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
    public class AvaliacaoesController : ControllerBase
    {
        private readonly AvaliacaoService avaliacao;

        public AvaliacaoesController(AvaliacaoService avaliacao)
        {
            this.avaliacao = avaliacao;
        }

        // GET: api/Avaliacaoes
        [HttpGet("All/")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAllAvaliacaosDb()
        {
            return await avaliacao.GetAllAvaliacoes();
        }

        // GET: api/Avaliacaoes/5
        [HttpGet("All/{idPizza}")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAllAvaliacaoByPizzaId(int id)
        {           
            return avaliacao.GetAvaliacoesByIdPizza(id);
        }

        [HttpGet("One/{idAv}")]
        public async Task<ActionResult<Avaliacao>> GetOneAvaliacaoByPizzaId(int idAv)
        {
            return await avaliacao.GetOneAvaliacaoOfPizza(idAv);
        }
        

        // PUT: api/Avaliacaoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Req/{id}")]
        public async Task<ActionResult<Avaliacao>> PutAvaliacao(int id, Avaliacao av)
        {
            if (id != av.Id)
            {
                return BadRequest();
            }

           return await avaliacao.PutAvaliacao(id, av);
        }

        // POST: api/Avaliacaoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Req/{idPizza}")]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(int idPizza, Avaliacao av)
        {
            return await avaliacao.PostAvaliacao(idPizza,av);
        }

        // DELETE: api/Avaliacaoes/5
        [HttpDelete("Req/{id}")]
        public async Task<ActionResult<string>> DeleteAvaliacao(int id)
        {
            return await avaliacao.DeleteAvaliacao(id);
        }
    }
}
