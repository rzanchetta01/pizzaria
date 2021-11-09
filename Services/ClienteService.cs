using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Model;

namespace Pizzaria.Services
{
    public class ClienteService
    {
        private readonly AppDbContext dbContext;

        public ClienteService(AppDbContext context)
        {
            dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await dbContext.Clientes.ToListAsync();
        }

        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);

            return cliente;
        }

        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            dbContext.Entry(cliente).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            var p = await GetCliente(id);
            return p;
        }
      
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync();
            var p = await GetCliente(cliente.Id);

            return p;
        }

        public async Task<ActionResult<string>> DeleteCliente(int id)
        {
            var cliente = await dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return "OK";
            }
            return "FAIL";
        }
    }
}
