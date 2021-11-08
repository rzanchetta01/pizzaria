﻿using System;
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
    public class BebidasController : ControllerBase
    {
        private readonly BebidaService bs;

        public BebidasController(BebidaService bs)
        {
            this.bs = bs;
        }

        // GET: api/Bebidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await bs.GetBebidas();
        }

        // GET: api/Bebidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            return await bs.GetBebida(id);
        }

        // PUT: api/Bebidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Bebida>> PutBebida(int id, Bebida bebida)
        {
            return await bs.PutBebida(id, bebida);
        }

        // POST: api/Bebidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            return await bs.PostPBebida(bebida);
        }

        // DELETE: api/Bebidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteBebida(int id)
        {
            return await bs.DeleteBebida(id);
        }
    }
}