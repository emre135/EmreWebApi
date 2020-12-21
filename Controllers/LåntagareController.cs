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
            return await _context.Låntagare.ToListAsync();
        }

        // GET: api/Låntagare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Låntagare>> GetLåntagare(int id)
        {
            var låntagare = await _context.Låntagare.FindAsync(id);

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
            if (id != låntagare.Lånekort)
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
            _context.Låntagare.Add(låntagare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLåntagare", new { id = låntagare.Lånekort }, låntagare);
        }

        // DELETE: api/Låntagare/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Låntagare>> DeleteLåntagare(int id)
        {
            var låntagare = await _context.Låntagare.FindAsync(id);
            if (låntagare == null)
            {
                return NotFound();
            }

            _context.Låntagare.Remove(låntagare);
            await _context.SaveChangesAsync();

            return låntagare;
        }

        private bool LåntagareExists(int id)
        {
            return _context.Låntagare.Any(e => e.Lånekort == id);
        }
    }
}
