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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService clienteService;

        public ClientesController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: api/Clientes
        [HttpGet("All/")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await clienteService.GetClientes();
        }

        // GET: api/Clientes/5
        [HttpGet("One/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {          
            return await clienteService.GetCliente(id);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Req/{id}")]
        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            return await clienteService.PutCliente(id, cliente);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Req/")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
           return await clienteService.PostCliente(cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("Req/{id}")]
        public async Task<ActionResult<string>> DeleteClienteController(int id)
        {
            return await clienteService.DeleteCliente(id);
        }
    }
}
