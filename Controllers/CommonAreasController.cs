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
    public class CommonAreasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommonAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommonAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommonAreas.ToListAsync());
        }

        // GET: CommonAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonArea = await _context.CommonAreas
                .FirstOrDefaultAsync(m => m.CommonAreaId == id);
            if (commonArea == null)
            {
                return NotFound();
            }

            return View(commonArea);
        }

        // GET: CommonAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommonAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommonAreaId,Name")] CommonArea commonArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commonArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commonArea);
        }

        // GET: CommonAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonArea = await _context.CommonAreas.FindAsync(id);
            if (commonArea == null)
            {
                return NotFound();
            }
            return View(commonArea);
        }

        // POST: CommonAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommonAreaId,Name")] CommonArea commonArea)
        {
            if (id != commonArea.CommonAreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commonArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommonAreaExists(commonArea.CommonAreaId))
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
            return View(commonArea);
        }

        // GET: CommonAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonArea = await _context.CommonAreas
                .FirstOrDefaultAsync(m => m.CommonAreaId == id);
            if (commonArea == null)
            {
                return NotFound();
            }

            return View(commonArea);
        }

        // POST: CommonAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commonArea = await _context.CommonAreas.FindAsync(id);
            _context.CommonAreas.Remove(commonArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommonAreaExists(int id)
        {
            return _context.CommonAreas.Any(e => e.CommonAreaId == id);
        }
    }
}
