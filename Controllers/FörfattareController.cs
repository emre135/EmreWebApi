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
    public class FörfattareController : ControllerBase
    {
        private readonly Context _context;

        public FörfattareController(Context context)
        {
            _context = context;
        }

        // GET: api/Författare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Författare>>> GetFörfattares()
        {
            return await _context.Författares.ToListAsync();
        }

        // GET: api/Författare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Författare>> GetFörfattare(int id)
        {
            var författare = await _context.Författares.FindAsync(id);

            if (författare == null)
            {
                return NotFound();
            }

            return författare;
        }

        // PUT: api/Författare/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFörfattare(int id, Författare författare)
        {
            if (id != författare.FörfattareId)
            {
                return BadRequest();
            }

            _context.Entry(författare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FörfattareExists(id))
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

        // POST: api/Författare
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Författare>> PostFörfattare(Författare författare)
        {
            _context.Författares.Add(författare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFörfattare", new { id = författare.FörfattareId }, författare);
        }

        // DELETE: api/Författare/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Författare>> DeleteFörfattare(int id)
        {
            var författare = await _context.Författares.FindAsync(id);
            if (författare == null)
            {
                return NotFound();
            }

            _context.Författares.Remove(författare);
            await _context.SaveChangesAsync();

            return författare;
        }

        private bool FörfattareExists(int id)
        {
            return _context.Författares.Any(e => e.FörfattareId == id);
        }
    }
}
