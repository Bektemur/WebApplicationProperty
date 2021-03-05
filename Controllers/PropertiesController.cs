using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        [Authorize]
        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Properties.Include(p => p.User).Include(p => p.Project).Include(p => p.Station).Include(p => p.TypeProperties);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
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
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }
        
        [Authorize]
        // GET: Properties/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name");
            ViewData["Improvements"] = _context.Improvements.ToList();
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property properties, string street_number, string route, string subdistrict, string district, string postcode, string province, string country, string latitude, string longitude, string[] selectedBasic)
        {
            var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            properties.ApplicationUserId = currentUserID;
            properties.Public_date = DateTime.UtcNow;
            properties.Update_date = DateTime.UtcNow;
            properties.Number = street_number;
            properties.Street = route;
            properties.SubDistrict = subdistrict;
            properties.District = district;
            properties.ZipCode = postcode;
            properties.Province = province;
            properties.Country = country;
            properties.Latitude = latitude;
            properties.Longitude = longitude;
            var viewmodel = new List<ImprovementToProperty>();
            foreach (var item in selectedBasic)
            {
                viewmodel.Add(new ImprovementToProperty() { ImprovementId = Convert.ToInt32(item), PropertyId = properties.PropertyId, Type = _context.Improvements.Where(v=>v.Id == Convert.ToInt32(item)).Select(v=>v.Type).FirstOrDefault() });
            }
            properties.Improvements = viewmodel;
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
        [Authorize]
        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (properties == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name");
            ImprovmentsData(properties);
            return View(properties);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedBasic)
        {
            if (id == null)
            {
                return NotFound();
            }
            var properties = await _context.Properties
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId");
            
                if (await TryUpdateModelAsync<Property>(
                properties,
                "", c=>c.Name, c=> c.Description, c => c.Update_date 
                ))
                {
                var currentUserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                properties.ApplicationUserId = currentUserID;
                properties.Update_date = DateTime.UtcNow;

                UpdateImprovmentsProperty(selectedBasic, properties);
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
            UpdateImprovmentsProperty(selectedBasic, properties);
            ImprovmentsData(properties);
            return View(properties);
        }
        [Authorize]
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
        private void ImprovmentsData(Property property)
        {
            var allImprovements = _context.Improvements;
            var propertyToImprovement = new HashSet<int>(property.Improvements.Select(v=>v.ImprovementId));
            var viewModel = new List<ImprovmentsViewModel>();
            foreach (var improvement in allImprovements)
            {
                viewModel.Add(new ImprovmentsViewModel
                {
                    ImprovementId = improvement.Id,
                    Name = improvement.Name,
                    Assigned = propertyToImprovement.Contains(improvement.Id)
                });
            }
            ViewData["Improvments"] = viewModel;
        }
        private void UpdateImprovmentsProperty(string[] selectedImprovments, Property improvmentsToUpdate)
        {
            if (selectedImprovments == null)
            {
                improvmentsToUpdate.Improvements = new List<ImprovementToProperty>();
                return;
            }

            var selectedImprovmentHS = new HashSet<string>(selectedImprovments);
            var instructorCourses = new HashSet<int>(improvmentsToUpdate.Improvements.Select(c => c.Improvement.Id));
             
            foreach (var improvement in _context.Improvements)
            {
                if (selectedImprovmentHS.Contains(improvement.Id.ToString()))
                {
                    if (!instructorCourses.Contains(improvement.Id))
                    {
                        improvmentsToUpdate.Improvements.Add(new ImprovementToProperty { PropertyId = improvmentsToUpdate.PropertyId, ImprovementId = improvement.Id, Type = _context.Improvements.Where(v => v.Id == improvement.Id).Select(r=>r.Type).FirstOrDefault() });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(improvement.Id))
                    {
                        ImprovementToProperty improvementToRemove = improvmentsToUpdate.Improvements.SingleOrDefault(i => i.ImprovementId == improvement.Id);
                        _context.Remove(improvementToRemove);
                    }
                }
            }
        }
        private bool PropertiesExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }
        
    }
}
