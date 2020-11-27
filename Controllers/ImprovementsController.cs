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
    public class ImprovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImprovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Improvements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Improvements.ToListAsync());
        }

        // GET: Improvements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement = await _context.Improvements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (improvement == null)
            {
                return NotFound();
            }

            return View(improvement);
        }

        // GET: Improvements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Improvements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Improvement improvement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(improvement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(improvement);
        }

        // GET: Improvements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement = await _context.Improvements.FindAsync(id);
            if (improvement == null)
            {
                return NotFound();
            }
            return View(improvement);
        }

        // POST: Improvements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Improvement improvement)
        {
            if (id != improvement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(improvement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImprovementExists(improvement.Id))
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
            return View(improvement);
        }

        // GET: Improvements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement = await _context.Improvements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (improvement == null)
            {
                return NotFound();
            }

            return View(improvement);
        }

        // POST: Improvements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var improvement = await _context.Improvements.FindAsync(id);
            _context.Improvements.Remove(improvement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImprovementExists(int id)
        {
            return _context.Improvements.Any(e => e.Id == id);
        }
    }
}
