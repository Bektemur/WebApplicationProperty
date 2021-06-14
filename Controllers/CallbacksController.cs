using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel;

namespace WebApplicationProperty.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class CallbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CallbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Callbacks
        public async Task<IActionResult> Index(int skip = 0, int take = 20)
        {
            var applicationDbContext = _context.Callbacks.Include(c => c.Property).Skip(skip).Take(take);
            return View(await applicationDbContext.Select(x => new CallbackViewModel(x)).ToListAsync());
        }

        // GET: Callbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callbackModel = await _context.Callbacks
                .Include(c => c.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callbackModel == null)
            {
                return NotFound();
            }

            return View(callbackModel);
        }

        // GET: Callbacks/Create
        public IActionResult Create()
        {
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CallbackModel callbackModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callbackModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", callbackModel.PropertyId);
            return View(callbackModel);
        }

        // GET: Callbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callbackModel = await _context.Callbacks.FindAsync(id);
            if (callbackModel == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", callbackModel.PropertyId);
            return View(callbackModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CallbackModel callbackModel)
        {
            if (id != callbackModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callbackModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallbackModelExists(callbackModel.Id))
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
            ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyId", "PropertyId", callbackModel.PropertyId);
            return View(callbackModel);
        }

        // GET: Callbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callbackModel = await _context.Callbacks
                .Include(c => c.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callbackModel == null)
            {
                return NotFound();
            }

            return View(callbackModel);
        }

        // POST: Callbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var callbackModel = await _context.Callbacks.FindAsync(id);
            _context.Callbacks.Remove(callbackModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallbackModelExists(int id)
        {
            return _context.Callbacks.Any(e => e.Id == id);
        }
    }
}
