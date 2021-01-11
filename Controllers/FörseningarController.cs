using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmreWebApi.Controllers
{
    public class FörseningarController : Controller
    {

        
        private readonly Context _context;

        public FörseningarController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bokbibliotekContext = _context.Boklåns.Where(b => b.ReturDatum < DateTime.Now).Include(b => b.Bok).Include(b => b.Låntagare);
            return View(await bokbibliotekContext.ToListAsync());
        }
    }
}
