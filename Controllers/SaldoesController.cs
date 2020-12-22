using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmreWebApi.Data;
using EmreWebApi.Models;

namespace EmreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoesController : ControllerBase
    {
        private readonly Context _context;

        public SaldoesController(Context context)
        {
            _context = context;
        }

        // GET: api/Saldoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saldo>>> GetSaldo()
        {
            return await _context.Saldo.ToListAsync();
        }

        // GET: api/Saldoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saldo>> GetSaldo(int id)
        {
            var saldo = await _context.Saldo.FindAsync(id);

            if (saldo == null)
            {
                return NotFound();
            }

            return saldo;
        }

        // PUT: api/Saldoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaldo(int id, Saldo saldo)
        {
            if (id != saldo.SaldoId)
            {
                return BadRequest();
            }

            _context.Entry(saldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaldoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Saldoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Saldo>> PostSaldo(Saldo saldo)
        {
            _context.Saldo.Add(saldo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaldo", new { id = saldo.SaldoId }, saldo);
        }

        // DELETE: api/Saldoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Saldo>> DeleteSaldo(int id)
        {
            var saldo = await _context.Saldo.FindAsync(id);
            if (saldo == null)
            {
                return NotFound();
            }

            _context.Saldo.Remove(saldo);
            await _context.SaveChangesAsync();

            return saldo;
        }

        private bool SaldoExists(int id)
        {
            return _context.Saldo.Any(e => e.SaldoId == id);
        }
    }
}
