using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Model;

namespace Pizzaria.Services
{
    public class BebidaService
    {
        private readonly AppDbContext dbContext;

        public BebidaService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all pizzas
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {           
            return await dbContext.Bebidas.ToListAsync();
        }

        public async Task<Bebida> GetBebida(int id)
        {
            var bebida = await dbContext.Bebidas.FindAsync(id);

            return bebida;
        }

        public async Task<Bebida> PutBebida(int id, Bebida bebida)
        {

            dbContext.Entry(bebida).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            var p = await GetBebida(id);
            return p;
        }
        public async Task<ActionResult<Bebida>> PostPBebida(Bebida bebida)
        {
            bebida.Id = 0;
            dbContext.Bebidas.Add(bebida);
            await dbContext.SaveChangesAsync();
            var p = await GetBebida(bebida.Id);

            return p;
        }

        public async Task<ActionResult<string>> DeleteBebida(int id)
        {
            var bebida = await dbContext.Bebidas.FindAsync(id);
            if (bebida != null)
            {
                dbContext.Bebidas.Remove(bebida);
                await dbContext.SaveChangesAsync();
                return "OK";
            }
            return "FAIL";
        }
    }
}
