using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel;

namespace WebApplicationProperty.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropertiesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Properties.Include(p => p.User).Include(p => p.Project).Include(p => p.Station).Include(p => p.TypeProperties);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            var properties = new Property();
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name");
            ViewData["Improvements"] = _context.Improvements.ToList();
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property properties, string[] selectedFacilities, string[] selectedInteriors, string[] selectedFixtures, string[] selectedCommonArea, string[] selectedExtra, string[] selectedOther, string[] selectedBasic)
        {
            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            properties.ApplicationUserId = currentUserID;
            properties.Public_date = DateTime.UtcNow;
            properties.Update_date = DateTime.UtcNow;
            //if (properties.GalleryFiles != null)
            //{
            //    string folder = "images/";

            //    properties.FileDetails = new List<FileDetail>();

            //    foreach (var file in properties.GalleryFiles)
            //    {
            //        var gallery = new FileDetail()
            //        {
            //            Name = file.Name,
            //            URL = await UploadImage(folder, file)
            //        };
            //        properties.FileDetails.Add(gallery);
            //    }
            //}
            if (ModelState.IsValid)
            {
                _context.Add(properties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId", properties.StationId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId", properties.TypePropertyId);
            ViewData["Improvements"] = _context.Improvements.ToList();
            return View(properties);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", properties.ApplicationUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId", properties.StationId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId", properties.TypePropertyId);
            return View(properties);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Property properties)
        {
            if (id != properties.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(properties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertiesExists(properties.PropertyId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", properties.ApplicationUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId", properties.StationId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId", properties.TypePropertyId);
            return View(properties);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .Include(p => p.User)
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var properties = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertiesExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }
    }
}
