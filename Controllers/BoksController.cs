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
    public class BoksController : ControllerBase
    {
        private readonly Context _context;

        public BoksController(Context context)
        {
            _context = context;
        }

        // GET: api/Boks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bok>>> GetBöcker()
        {
            return await _context.Böcker.ToListAsync();
        }

        // GET: api/Boks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bok>> GetBok(int id)
        {
            var bok = await _context.Böcker.FindAsync(id);

            if (bok == null)
            {
                return NotFound();
            }

            return bok;
        }

        // PUT: api/Boks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBok(int id, Bok bok)
        {
            if (id != bok.Bok_Id)
            {
                return BadRequest();
            }

            _context.Entry(bok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BokExists(id))
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

        // POST: api/Boks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bok>> PostBok(Bok bok)
        {
            _context.Böcker.Add(bok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBok", new { id = bok.Bok_Id }, bok);
        }

        // DELETE: api/Boks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bok>> DeleteBok(int id)
        {
            var bok = await _context.Böcker.FindAsync(id);
            if (bok == null)
            {
                return NotFound();
            }

            _context.Böcker.Remove(bok);
            await _context.SaveChangesAsync();

            return bok;
        }

        private bool BokExists(int id)
        {
            return _context.Böcker.Any(e => e.Bok_Id == id);
        }
    }
}
