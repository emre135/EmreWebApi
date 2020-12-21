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
    public class BoklånController : ControllerBase
    {
        private readonly Context _context;

        public BoklånController(Context context)
        {
            _context = context;
        }

        // GET: api/Boklån
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boklån>>> GetBoklån()
        {
            return await _context.Boklån.ToListAsync();
        }

        // GET: api/Boklån/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boklån>> GetBoklån(int id)
        {
            var boklån = await _context.Boklån.FindAsync(id);

            if (boklån == null)
            {
                return NotFound();
            }

            return boklån;
        }

        // PUT: api/Boklån/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoklån(int id, Boklån boklån)
        {
            if (id != boklån.Boklån_Id)
            {
                return BadRequest();
            }

            _context.Entry(boklån).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoklånExists(id))
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

        // POST: api/Boklån
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Boklån>> PostBoklån(Boklån boklån)
        {
            _context.Boklån.Add(boklån);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoklån", new { id = boklån.Boklån_Id }, boklån);
        }

        // DELETE: api/Boklån/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boklån>> DeleteBoklån(int id)
        {
            var boklån = await _context.Boklån.FindAsync(id);
            if (boklån == null)
            {
                return NotFound();
            }

            _context.Boklån.Remove(boklån);
            await _context.SaveChangesAsync();

            return boklån;
        }

        private bool BoklånExists(int id)
        {
            return _context.Boklån.Any(e => e.Boklån_Id == id);
        }
    }
}
