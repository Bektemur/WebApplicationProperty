using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel;

namespace WebApplicationProperty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Search(int[] selectedBasic, int page = 1, int take = 25, int id = 0)
        {
            IndexViewModel indexViewModel = await GetIndexViewModel(selectedBasic,0,"",0,0,0, "", page, take, id);
            return View(indexViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SearchResult(int[] selectedBasic, int propertyContractType, string propertyTypes, int propertyBedrooms, double minvalue, double maxvalue, string search, int page = 1, int take = 25, int id = 0)
        {
            IndexViewModel indexViewModel = await GetIndexViewModel(selectedBasic, propertyContractType, propertyTypes, propertyBedrooms, minvalue, maxvalue, search, page, take, id);
            return PartialView("_PropertySearchPartial", indexViewModel);
        }

        public IActionResult Index(int page = 1, int take = 25, int id = 0)
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = _context.Properties.Include(x => x.FileSystemModels).Skip(page - 1).Take(take).ToList(),
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = _context.Properties
                .Include(p => p.Project)
                .Include(p => p.Station)
                .Include(p => p.TypeProperties)
                .Include(p => p.Improvements).ThenInclude(x => x.Improvement).Include(p => p.FileSystemModels)
                .FirstOrDefault(m => m.PropertyId == id)
            };
            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Details(int[] selectImropments, int id, int page = 1, int take = 25)
        {
            IndexViewModel indexViewModel = await GetIndexViewModel(selectImropments,0,"",0,0,0, "", page, take, id);
            if (indexViewModel == null)
            {
                return NotFound();
            }

            return View(indexViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int[] selectedImprovments, Contact contact, string Name, string Email, string Phone, string Description, int id, int page = 1, int take = 25)
        {
            contact.PropertyId = id;
            contact.Name = Name;
            contact.Phone = Phone;
            contact.Email = Email;
            contact.Description = Description;
            contact.DateTime = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
            }
            IndexViewModel indexViewModel = await GetIndexViewModel(selectedImprovments,0,"", 0,0,0,"", page, take, id);
            if (indexViewModel == null)
            {
                return NotFound();
            }
            return View(indexViewModel);
        }
        public IActionResult About()
        {
            return View();
        }

        
        public async Task<IndexViewModel> GetIndexViewModel(int[] selectedImprovments, int propertyContractType,string propertyTypes, int propertyBedrooms, double minvalue, double maxvalue, string search, int page = 1, int take = 25, int id = 0)
        {
            var propertyById = id <= 0 ? null : _context.Properties
               .Include(p => p.Project)
               .Include(p => p.Station)
               .Include(p => p.TypeProperties)
               .Include(p => p.Improvements).Include(p => p.FileSystemModels)
               .FirstOrDefault(m => m.PropertyId == id);

            var query = _context.Properties.Include(x => x.FileSystemModels).Include(x => x.Improvements).AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(v => v.Name.Contains(search)).AsQueryable();
            }
            if (selectedImprovments.Length > 0)
            {
                query = query.Where(u => u.Improvements.Any(x => selectedImprovments.Contains(x.ImprovementId))).AsQueryable();
            }
            if (propertyContractType == 1)
            {
                query = query.Where(c=>c.ForRent);
            }
            if (propertyContractType == 2)
            {
                query = query.Where(c=>c.ForSale);
            }
            if( propertyTypes != null)
            {
                query = query.Where(c=>c.TypeProperties.Name.Contains(propertyTypes));
            }
            if (propertyBedrooms != 0)
            {
                query = query.Where(c=>c.Bedrooms == propertyBedrooms);
            }
            if (maxvalue>0 && minvalue>0 && propertyContractType == 1)
            {
                query = query.Where(c=>c.Price_rent <= maxvalue && c.Price_rent >= minvalue);
            }
            if (maxvalue>0 && minvalue>0)
            {
                query = query.Where(c=>c.Price <= maxvalue && c.Price >= minvalue);
            }
            var propertyList = await query.Skip((page - 1) * take).Take(take).ToListAsync();
            
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = propertyList,
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = propertyById
            };
            return indexViewModel;
        }
    }
}
