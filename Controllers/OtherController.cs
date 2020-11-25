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
    public class OtherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Other
        public async Task<IActionResult> Index()
        {
            return View(await _context.Others.ToListAsync());
        }

        // GET: Other/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others
                .FirstOrDefaultAsync(m => m.OtherId == id);
            if (other == null)
            {
                return NotFound();
            }

            return View(other);
        }

        // GET: Other/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Other/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OtherId,Name")] Other other)
        {
            if (ModelState.IsValid)
            {
                _context.Add(other);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(other);
        }

        // GET: Other/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others.FindAsync(id);
            if (other == null)
            {
                return NotFound();
            }
            return View(other);
        }

        // POST: Other/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OtherId,Name")] Other other)
        {
            if (id != other.OtherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(other);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherExists(other.OtherId))
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
            return View(other);
        }

        // GET: Other/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others
                .FirstOrDefaultAsync(m => m.OtherId == id);
            if (other == null)
            {
                return NotFound();
            }

            return View(other);
        }

        // POST: Other/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var other = await _context.Others.FindAsync(id);
            _context.Others.Remove(other);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherExists(int id)
        {
            return _context.Others.Any(e => e.OtherId == id);
        }
    }
}
