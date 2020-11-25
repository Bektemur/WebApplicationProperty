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
    public class BasicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Basics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Basics.ToListAsync());
        }

        // GET: Basics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.Basics
                .FirstOrDefaultAsync(m => m.BasicId == id);
            if (basic == null)
            {
                return NotFound();
            }

            return View(basic);
        }

        // GET: Basics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Basics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasicId,Name")] Basic basic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basic);
        }

        // GET: Basics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.Basics.FindAsync(id);
            if (basic == null)
            {
                return NotFound();
            }
            return View(basic);
        }

        // POST: Basics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BasicId,Name")] Basic basic)
        {
            if (id != basic.BasicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicExists(basic.BasicId))
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
            return View(basic);
        }

        // GET: Basics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.Basics
                .FirstOrDefaultAsync(m => m.BasicId == id);
            if (basic == null)
            {
                return NotFound();
            }

            return View(basic);
        }

        // POST: Basics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basic = await _context.Basics.FindAsync(id);
            _context.Basics.Remove(basic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicExists(int id)
        {
            return _context.Basics.Any(e => e.BasicId == id);
        }
    }
}
