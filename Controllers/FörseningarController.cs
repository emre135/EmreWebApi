using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmreWebApi.Data;
using EmreWebApi.Models;

namespace EmreWebApi.Controllers
{
    public class FörseningarController : Controller
    {
        private readonly Context _context;

        public FörseningarController(Context context)
        {
            _context = context;
        }

        // GET: Förseningar
        public async Task<IActionResult> Index()
        {
            var context = _context.Boklåns.Include(b => b.Saldo);
            return View(await context.ToListAsync());
        }

        // GET: Förseningar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boklån = await _context.Boklåns
                .Include(b => b.Saldo)
                .FirstOrDefaultAsync(m => m.BoklånId == id);
            if (boklån == null)
            {
                return NotFound();
            }

            return View(boklån);
        }

        // GET: Förseningar/Create
        public IActionResult Create()
        {
            ViewData["SaldoId"] = new SelectList(_context.Saldos, "SaldoId", "SaldoId");
            return View();
        }

        // POST: Förseningar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoklånId,Utlånad,LåneDatum,ReturDatum,LånekortId,SaldoId")] Boklån boklån)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boklån);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SaldoId"] = new SelectList(_context.Saldos, "SaldoId", "SaldoId", boklån.SaldoId);
            return View(boklån);
        }

        // GET: Förseningar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boklån = await _context.Boklåns.FindAsync(id);
            if (boklån == null)
            {
                return NotFound();
            }
            ViewData["SaldoId"] = new SelectList(_context.Saldos, "SaldoId", "SaldoId", boklån.SaldoId);
            return View(boklån);
        }

        // POST: Förseningar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoklånId,Utlånad,LåneDatum,ReturDatum,LånekortId,SaldoId")] Boklån boklån)
        {
            if (id != boklån.BoklånId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boklån);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoklånExists(boklån.BoklånId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SaldoId"] = new SelectList(_context.Saldos, "SaldoId", "SaldoId", boklån.SaldoId);
            return View(boklån);
        }

        // GET: Förseningar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boklån = await _context.Boklåns
                .Include(b => b.Saldo)
                .FirstOrDefaultAsync(m => m.BoklånId == id);
            if (boklån == null)
            {
                return NotFound();
            }

            return View(boklån);
        }

        // POST: Förseningar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boklån = await _context.Boklåns.FindAsync(id);
            _context.Boklåns.Remove(boklån);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoklånExists(int id)
        {
            return _context.Boklåns.Any(e => e.BoklånId == id);
        }
    }
}
