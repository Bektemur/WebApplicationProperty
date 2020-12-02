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
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contract
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContractTypes.ToListAsync());
        }

        // GET: Contract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _context.ContractTypes
                .FirstOrDefaultAsync(m => m.ContractTypeId == id);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // GET: Contract/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractTypeId,Name")] ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractType);
        }

        // GET: Contract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _context.ContractTypes.FindAsync(id);
            if (contractType == null)
            {
                return NotFound();
            }
            return View(contractType);
        }

        // POST: Contract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractTypeId,Name")] ContractType contractType)
        {
            if (id != contractType.ContractTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractTypeExists(contractType.ContractTypeId))
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
            return View(contractType);
        }

        // GET: Contract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractType = await _context.ContractTypes
                .FirstOrDefaultAsync(m => m.ContractTypeId == id);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractType = await _context.ContractTypes.FindAsync(id);
            _context.ContractTypes.Remove(contractType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractTypeExists(int id)
        {
            return _context.ContractTypes.Any(e => e.ContractTypeId == id);
        }
    }
}
