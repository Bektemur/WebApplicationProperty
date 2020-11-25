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
    public class TypePropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypePropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeProperties.ToListAsync());
        }

        // GET: TypeProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperty = await _context.TypeProperties
                .FirstOrDefaultAsync(m => m.TypePropertyId == id);
            if (typeProperty == null)
            {
                return NotFound();
            }

            return View(typeProperty);
        }

        // GET: TypeProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypePropertyId,Name")] TypeProperty typeProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProperty);
        }

        // GET: TypeProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperty = await _context.TypeProperties.FindAsync(id);
            if (typeProperty == null)
            {
                return NotFound();
            }
            return View(typeProperty);
        }

        // POST: TypeProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypePropertyId,Name")] TypeProperty typeProperty)
        {
            if (id != typeProperty.TypePropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypePropertyExists(typeProperty.TypePropertyId))
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
            return View(typeProperty);
        }

        // GET: TypeProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProperty = await _context.TypeProperties
                .FirstOrDefaultAsync(m => m.TypePropertyId == id);
            if (typeProperty == null)
            {
                return NotFound();
            }

            return View(typeProperty);
        }

        // POST: TypeProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeProperty = await _context.TypeProperties.FindAsync(id);
            _context.TypeProperties.Remove(typeProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypePropertyExists(int id)
        {
            return _context.TypeProperties.Any(e => e.TypePropertyId == id);
        }
    }
}
