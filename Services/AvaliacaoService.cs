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
        }


        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes(int idPizza)
        {
            var pizza = await ps.GetPizza(idPizza);

            return pizza.Avaliacoes.ToList();
        }

        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int idPizza, int idAvaliacao)
        {
            var pizza = await ps.GetPizza(idPizza);
            var avaliacao =  pizza.Avaliacoes.FirstOrDefault(a => a.Id == idAvaliacao);

            return avaliacao;            
        }
        /*
        public async Task<ActionResult<Avaliacao>> PutAvaliacao(int idAvaliacao, Avaliacao av)
        {
            dbContext.Entry(av).State = EntityState.Modified;      
            await dbContext.SaveChangesAsync();

            var result = await GetAvaliacao(idPizza, idAvaliacao);

            return result;
           
        }
        public async Task<ActionResult<Pizza>> PostAvaliacao(int idPizza, Avaliacao av)
        {
            dbContext.Pizzas.Add(pizza);
            await dbContext.SaveChangesAsync();
            var p = await GetPizza(pizza.Id);

            return p;
        }

        public async Task<ActionResult<string>> DeletePizza(int id)
        {
            var pizza = await dbContext.Pizzas.FindAsync(id);
            if(pizza != null)
            {
                dbContext.Pizzas.Remove(pizza);
                await dbContext.SaveChangesAsync();
                return "OK";
            }
            return "FAIL";
        }*/
    }
}
