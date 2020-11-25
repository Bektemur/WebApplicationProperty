using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.Controllers
{
    public class InteriorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InteriorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interiors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interiors.ToListAsync());
        }

        // GET: Interiors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interior = await _context.Interiors
                .FirstOrDefaultAsync(m => m.InteriorId == id);
            if (interior == null)
            {
                return NotFound();
            }

            return View(interior);
        }

        // GET: Interiors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interiors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InteriorId,Name")] Interior interior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interior);
        }

        // GET: Interiors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interior = await _context.Interiors.FindAsync(id);
            if (interior == null)
            {
                return NotFound();
            }
            return View(interior);
        }

        // POST: Interiors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InteriorId,Name")] Interior interior)
        {
            if (id != interior.InteriorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteriorExists(interior.InteriorId))
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
            return View(interior);
        }

        // GET: Interiors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interior = await _context.Interiors
                .FirstOrDefaultAsync(m => m.InteriorId == id);
            if (interior == null)
            {
                return NotFound();
            }

            return View(interior);
        }

        // POST: Interiors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interior = await _context.Interiors.FindAsync(id);
            _context.Interiors.Remove(interior);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteriorExists(int id)
        {
            return _context.Interiors.Any(e => e.InteriorId == id);
        }
    }
}
