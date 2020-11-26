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
            var applicationDbContext = _context.Properties.Include(p => p.ApplicationUser).Include(p => p.Project).Include(p => p.Station).Include(p => p.TypeProperties);
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
            var properties = new Properties();
            properties.ExtraProperies = new List<ExtraProperies>();
            properties.FacilitiesProperties = new List<FacilitiesProperty>();
            properties.FixturesProperties = new List<FixturesProperty>();
            properties.InteriorProperties = new List<InteriorProperties>();
            properties.OtherProperties = new List<OtherProperties>();
            properties.BasicProperties = new List<BasicProperties>();
            properties.CommonAreaProperties = new List<CommonAreaProperties>();
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Name");
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "Name");
            FacilitiesData(properties);
            InteriorsData(properties);
            FixturesData(properties);
            ExtraData(properties);
            OtherData(properties);
            CommonAreaData(properties);
            BasicData(properties);
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,Name,Description,Price,Price_sqm,Living_area,Land_area,Bathrooms,Bedrooms,Parking,Public_date,Update_date,TypePropertyId,ProjectId,StationId,ApplicationUserId")] Properties properties, string[] selectedFacilities, string[] selectedInteriors, string[] selectedFixtures, string[] selectedCommonArea, string[] selectedExtra, string[] selectedOther, string[] selectedBasic)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            properties.ApplicationUserId = currentUserID;
            properties.Public_date = DateTime.Now;
            properties.Update_date = DateTime.Now;
            if (selectedFacilities != null)
            {
                properties.FacilitiesProperties = new List<FacilitiesProperty>();
                foreach (var item in selectedFacilities)
                {
                    var facilitiesToAdd = new FacilitiesProperty { PropertyId = properties.PropertyId, FacilitiesId = int.Parse(item) };
                    properties.FacilitiesProperties.Add(facilitiesToAdd);
                }
            }
            if (selectedInteriors != null)
            {
                properties.InteriorProperties = new List<InteriorProperties>();
                foreach (var item in selectedInteriors)
                {
                    var interiorsToAdd = new InteriorProperties { PropertiesId = properties.PropertyId, InteriorId = int.Parse(item) };
                    properties.InteriorProperties.Add(interiorsToAdd);
                }
            }
            if (selectedFixtures != null)
            {
                properties.FixturesProperties = new List<FixturesProperty>();
                foreach (var item in selectedFixtures)
                {
                    var fixturesToAdd = new FixturesProperty { PropertiesId = properties.PropertyId, FixturesId = int.Parse(item) };
                    properties.FixturesProperties.Add(fixturesToAdd);
                }
            }
            if (selectedCommonArea != null)
            {
                properties.CommonAreaProperties = new List<CommonAreaProperties>();
                foreach (var item in selectedCommonArea)
                {
                    var commonAreaToAdd = new CommonAreaProperties { PropertiesId = properties.PropertyId, CommonAreaId = int.Parse(item) };
                    properties.CommonAreaProperties.Add(commonAreaToAdd);
                }
            }
            if (selectedExtra != null)
            {
                properties.ExtraProperies = new List<ExtraProperies>();
                foreach (var item in selectedExtra)
                {
                    var extraToAdd = new ExtraProperies { PropertiesId = properties.PropertyId, ExtraId = int.Parse(item) };
                    properties.ExtraProperies.Add(extraToAdd);
                }
            }
            if (selectedOther != null)
            {
                properties.OtherProperties = new List<OtherProperties>();
                foreach (var item in selectedOther)
                {
                    var otherToAdd = new OtherProperties { PropertiesId = properties.PropertyId, OtherId = int.Parse(item) };
                    properties.OtherProperties.Add(otherToAdd);
                }
            }
            if (selectedBasic != null)
            {
                properties.BasicProperties = new List<BasicProperties>();
                foreach (var item in selectedBasic)
                {
                    var basicToAdd = new BasicProperties { PropertiesId = properties.PropertyId, BasicId = int.Parse(item) };
                    properties.BasicProperties.Add(basicToAdd);
                }
            }
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
            FacilitiesData(properties);
            InteriorsData(properties);
            FixturesData(properties);
            ExtraData(properties);
            OtherData(properties);
            CommonAreaData(properties);
            BasicData(properties);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId", properties.StationId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId", properties.TypePropertyId);
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", properties.ApplicationUserId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", properties.ProjectId);
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "StationId", properties.StationId);
            ViewData["TypePropertyId"] = new SelectList(_context.TypeProperties, "TypePropertyId", "TypePropertyId", properties.TypePropertyId);
            return View(properties);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,Name,Description,Price,Price_sqm,Living_area,Land_area,Bathrooms,Bedrooms,Parking,Public_date,Update_date,TypePropertyId,ProjectId,StationId,ApplicationUserId")] Properties properties)
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", properties.ApplicationUserId);
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
                .Include(p => p.ApplicationUser)
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
        private void FacilitiesData(Properties properties)
        {
            var allFacilities = _context.Facilities;
            var propertyFacilities = new HashSet<int>(properties.FacilitiesProperties.Select(c => c.FacilitiesId));
            var viewModel = new List<FacilitiesPropertiesViewModel>();
            foreach (var facilities in allFacilities)
            {
                viewModel.Add(new FacilitiesPropertiesViewModel
                {
                    FacilitiesId = facilities.FacilitiesId,
                    Name = facilities.Name,
                    Assigned = propertyFacilities.Contains(facilities.FacilitiesId)
                });
            }
            ViewBag.Facilities = viewModel;
        }
        private void InteriorsData(Properties properties)
        {
            var allInteriors = _context.Interiors;
            var propertyInteriors = new HashSet<int>(properties.InteriorProperties.Select(c => c.InteriorId));
            var viewModel = new List<InteriorPropertiesViewModel>();
            foreach (var interior in allInteriors)
            {
                viewModel.Add(new InteriorPropertiesViewModel
                {
                    InteriorId = interior.InteriorId,
                    Name = interior.Name,
                    Assigned = propertyInteriors.Contains(interior.InteriorId)
                });
            }
            ViewBag.Interiors = viewModel;
        }
        private void FixturesData(Properties properties)
        {
            var allFixtures = _context.Fixtures;
            var propertyFixtures = new HashSet<int>(properties.FixturesProperties.Select(c => c.FixturesId));
            var viewModel = new List<FixturesPropertiesViewModel>();
            foreach (var fixtures in allFixtures)
            {
                viewModel.Add(new FixturesPropertiesViewModel
                {
                    FixturesId = fixtures.FixturesId,
                    Name = fixtures.Name,
                    Assigned = propertyFixtures.Contains(fixtures.FixturesId)
                });
            }
            ViewBag.Fixtures = viewModel;
        }
        private void ExtraData(Properties properties)
        {
            var allExtra = _context.Extras;
            var propertyExtra = new HashSet<int>(properties.ExtraProperies.Select(c => c.ExtraId));
            var viewModel = new List<ExtraPropertiesViewModel>();
            foreach (var extra in allExtra)
            {
                viewModel.Add(new ExtraPropertiesViewModel
                {
                    ExtraId = extra.ExtraId,
                    Name = extra.Name,
                    Assigned = propertyExtra.Contains(extra.ExtraId)
                });
            }
            ViewBag.Extra = viewModel;
        }
        private void OtherData(Properties properties)
        {
            var allOther = _context.Others;
            var propertyOther = new HashSet<int>(properties.OtherProperties.Select(c => c.OtherId));
            var viewModel = new List<OtherPropertiesViewModel>();
            foreach (var other in allOther)
            {
                viewModel.Add(new OtherPropertiesViewModel
                {
                    OtherId = other.OtherId,
                    Name = other.Name,
                    Assigned = propertyOther.Contains(other.OtherId)
                });
            }
            ViewBag.Other = viewModel;
        }
        private void CommonAreaData(Properties properties)
        {
            var allCommonArea = _context.CommonAreas;
            var propertyCommonArea = new HashSet<int>(properties.CommonAreaProperties.Select(c => c.CommonAreaId));
            var viewModel = new List<CommonAreaPropertiesViewModel>();
            foreach (var commonArea in allCommonArea)
            {
                viewModel.Add(new CommonAreaPropertiesViewModel
                {
                    CommonAreaId = commonArea.CommonAreaId,
                    Name = commonArea.Name,
                    Assigned = propertyCommonArea.Contains(commonArea.CommonAreaId)
                });
            }
            ViewBag.CommonArea = viewModel;
        }
        private void BasicData(Properties properties)
        {
            var allBasic = _context.Basics;
            var propertyBasic = new HashSet<int>(properties.BasicProperties.Select(c => c.BasicId));
            var viewModel = new List<BasicPropertiesViewModel>();
            foreach (var basic in allBasic)
            {
                viewModel.Add(new BasicPropertiesViewModel
                {
                    BasicId = basic.BasicId,
                    Name = basic.Name,
                    Assigned = propertyBasic.Contains(basic.BasicId)
                });
            }
            ViewBag.Basic = viewModel;
        }
    }
}
