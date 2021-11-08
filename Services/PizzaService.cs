using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Model;

namespace Pizzaria.Services
{
    public class PizzaService
    {

        private readonly AppDbContext dbContext;

        public PizzaService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all pizzas
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await dbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            var pizza = await dbContext.Pizzas.FindAsync(id);

            return pizza;
        }

        public async Task<Pizza> PutPizza(int id, Pizza pizza)
        {

            dbContext.Entry(pizza).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            var p = await GetPizza(id);
            return p;
        }
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
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
        }


    }
}
