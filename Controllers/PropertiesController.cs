using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel;
using WebApplicationProperty.ViewModel.Properties;

namespace WebApplicationProperty.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertiesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name");
            ViewData["Improvements"] = _context.Improvements.ToList();
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyViewModel properties)
        {
            properties.ApplicationUserId = GetCurrentUserId();
            properties.PublicDate = DateTime.UtcNow;
            properties.UpdateDate = DateTime.UtcNow;
            var allImprovments = _context.Improvements.ToList();
            var improvments = new List<ImprovementToProperty>();
            foreach (var item in properties.SelectedBasic)
            {
                improvments.Add(new ImprovementToProperty()
                {
                    ImprovementId = Convert.ToInt32(item),
                    PropertyId = properties.PropertyId,
                    Type = allImprovments.Where(v => v.Id == Convert.ToInt32(item)).Select(v => v.Type).FirstOrDefault()
                });
            }
            properties.Improvements = improvments;
            if (ModelState.IsValid)
            {
                _context.Add(properties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", properties.StationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", properties.CityId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name", properties.TypePropertyId);
            ViewData["Improvements"] = allImprovments;
            return View(properties);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (property == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", property.ApplicationUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", property.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", property.StationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", property.CityId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name", property.TypePropertyId);
            LoadImprovmentsToViewData(property);
            return View(_mapper.Map<PropertyViewModel>(property));
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, PropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var property = await _context.Properties
                    .Include(p => p.Project)
                    .Include(p => p.Station)
                    .Include(p => p.TypeProperties)
                    .Include(p => p.Improvements)
                    .ThenInclude(x => x.Improvement)
                    .Include(p => p.FileSystemModels)
                    .FirstOrDefaultAsync(m => m.PropertyId == id);

                property = _mapper.Map<Property>(model);
                property.ApplicationUserId = GetCurrentUserId();
                property.UpdateDate = DateTime.UtcNow;
                if (property.PublicDate <= DateTime.MinValue)
                {
                    property.PublicDate = DateTime.UtcNow;
                }

                UpdateImprovmentsProperty(model.SelectedBasic, property);
                try
                {
                    _context.Update(property);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertiesExists(property.PropertyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name", model.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", model.StationId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name", model.CityId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name", model.TypePropertyId);
            LoadImprovmentsToViewData(model);
            return View(model);
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

        private void LoadImprovmentsToViewData(Property property)
        {
            var allImprovements = _context.Improvements.ToList();
            var propertyToImprovement = property?.Improvements?.Select(v => v.ImprovementId).ToList() ?? new List<int>();
            var improvments = new List<ImprovmentsViewModel>();
            foreach (var improvement in allImprovements)
            {
                improvments.Add(new ImprovmentsViewModel
                {
                    ImprovementId = improvement.Id,
                    Name = improvement.Name,
                    Type = improvement.Type,
                    Assigned = propertyToImprovement.Contains(improvement.Id)
                });
            }
            ViewData["Improvements"] = improvments;
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
            var allImprovments = _context.Improvements.ToList();
            foreach (var improvement in allImprovments)
            {
                if (selectedImprovmentHS.Contains(improvement.Id.ToString()))
                {
                    if (!instructorCourses.Contains(improvement.Id))
                    {
                        improvmentsToUpdate.Improvements.Add(new ImprovementToProperty
                        {
                            PropertyId = improvmentsToUpdate.PropertyId,
                            ImprovementId = improvement.Id,
                            Type = allImprovments.Where(v => v.Id == improvement.Id).Select(r => r.Type).FirstOrDefault()
                        });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(improvement.Id))
                    {
                        var improvementToRemove = improvmentsToUpdate.Improvements.FirstOrDefault(i => i.ImprovementId == improvement.Id);
                        _context.Remove(improvementToRemove);
                    }
                }
            }
        }
        private bool PropertiesExists(int id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
