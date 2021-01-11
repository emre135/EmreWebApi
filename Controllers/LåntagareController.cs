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
    public class LåntagareController : ControllerBase
    {
        private readonly Context _context;

        public LåntagareController(Context context)
        {
            _context = context;
        }

        // GET: api/Låntagare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Låntagare>>> GetLåntagare()
        {
            return await _context.Låntagares.ToListAsync();
        }

        // GET: api/Låntagare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Låntagare>> GetLåntagare(int id)
        {
            var låntagare = await _context.Låntagares.FindAsync(id);

            if (låntagare == null)
            {
                return NotFound();
            }

            return låntagare;
        }

        // PUT: api/Låntagare/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLåntagare(int id, Låntagare låntagare)
        {
            if (id != låntagare.LånekortId)
            {
                return BadRequest();
            }

            _context.Entry(låntagare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LåntagareExists(id))
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

        // POST: api/Låntagare
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Låntagare>> PostLåntagare(Låntagare låntagare)
        {
           
            _context.Låntagares.Add(låntagare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLåntagare", new { id = låntagare.LånekortId }, låntagare);
        }

        // DELETE: api/Låntagare/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Låntagare>> DeleteLåntagare(int id)
        {
            var låntagare = await _context.Låntagares.FindAsync(id);
            if (låntagare == null)
            {
                return NotFound();
            }

            _context.Låntagares.Remove(låntagare);
            await _context.SaveChangesAsync();

            return låntagare;
        }

        private bool LåntagareExists(int id)
        {
            return _context.Låntagares.Any(e => e.LånekortId == id);
        }

        // HYR BOK

        [HttpPost("{lånekortId}/hyrbok/{bokId}")]
        public async Task<ActionResult<Låntagare>> HyrBok(int lånekortId, int bokId)
        {
            var lånetagare = await _context.Låntagares
                .SingleOrDefaultAsync(c => c.LånekortId == lånekortId);

            if (lånetagare == null)
            {
                return BadRequest("Lånetagare existerar inte!");
            }

           
            var saldo = await _context.Saldo
                .Include(i => i.Bok)
                .Include(i => i.Boklåns)
                .Where(i => i.BokId == bokId)
                .ToListAsync();

           
            var tillgängligSaldo = saldo.FirstOrDefault(i => i.Tillgänglig);

            if (tillgängligSaldo == null)
            {
                return BadRequest("Boken är inte tillgänlig!");
            }

            var boklån = new Boklån()
            {
                LånekortId = lånekortId,
                SaldoId = tillgängligSaldo.SaldoId,
                LåneDatum = DateTime.Now,
                ReturDatum = DateTime.Now.AddDays(1)
            };

            _context.Boklåns.Add(boklån);
            await _context.SaveChangesAsync();

            return Ok($"Lånetagare {lånetagare.Förnamn} har hyrt {tillgängligSaldo.Bok.BokTitel} klockan {boklån.LåneDatum}");
        }


        // RETUR BOK

        [HttpPost("{lånekortId}/returbok/{bokId}")]
        public async Task<ActionResult<Låntagare>> ReturBok(int lånekortId, int bokId)
        {
            
            var låntagare = await _context.Låntagares
                 .Include(i => i.Boklåns)
                 .ThenInclude(i => i.Saldo)
                 .ThenInclude(i => i.Bok)
                 .SingleOrDefaultAsync(c => c.LånekortId == lånekortId);


            if (låntagare == null)
            {
                return BadRequest("Låntagare existerar inte!");
            }

            if (låntagare.Boklåns == null || låntagare.Boklåns.Count == 0)
            {
                return BadRequest("Låntagaren har inte hyrt något!");
            }

        
            var boklån = låntagare.Boklåns.FirstOrDefault(b => b.Saldo.BokId == bokId && !b.Inlämnad);

            if (boklån == null)
            {
                return BadRequest("Låntagaren har inte hyrt den här boken.");
            }

            
            _context.Entry(boklån).State = EntityState.Modified;
            boklån.ReturDatum = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok($"Låntagaren {låntagare.Förnamn} har lämnat tillbaka boken \"{boklån.Saldo.Bok.BokTitel}\" klockan {boklån.ReturDatum}");
        }


    }
}
