using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Model;

namespace Pizzaria.Services
{
    public class AvaliacaoService
    { 
        private readonly AppDbContext dbContext;
        private readonly PizzaService ps;

        public AvaliacaoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            ps = new PizzaService(dbContext);
        }

        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAllAvaliacoes()
        {
            return await dbContext.AvaliacaosDb.ToListAsync();
        }

        public ActionResult<IEnumerable<Avaliacao>> GetAvaliacoesByIdPizza(int id)
        {
            List<Avaliacao> aux = new List<Avaliacao>();
            foreach (var e in dbContext.AvaliacaosDb.ToList())
            {
                if (e.IdPizza == id)
                {
                    aux.Add(e);
                }
            }
            return aux.ToList();
        }
        public async Task<ActionResult<Avaliacao>> GetOneAvaliacaoOfPizza(int idAvaliacao)
        {
            var avaliacao = await dbContext.AvaliacaosDb.FirstOrDefaultAsync(a => a.Id == idAvaliacao);

            return avaliacao;
        }

        public async Task<ActionResult<Avaliacao>> PutAvaliacao(int idAvaliacao, Avaliacao av)
        {
            dbContext.Entry(av).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            var result = await GetOneAvaliacaoOfPizza(av.Id);

            return result;

        }
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(int idPizza, Avaliacao av)
        {
            dbContext.AvaliacaosDb.Add(av);
            await dbContext.SaveChangesAsync();
            var p = await GetOneAvaliacaoOfPizza(av.Id);

            return p;
        }

        public async Task<ActionResult<string>> DeleteAvaliacao(int idAvaliacao)
        {
            var av = dbContext.AvaliacaosDb.FirstOrDefault(a => a.Id == idAvaliacao);
            if (av != null)
            {
                dbContext.AvaliacaosDb.Remove(av);
                await dbContext.SaveChangesAsync();
                return "OK";
            }
            return "FAIL";
        }
    }
}
