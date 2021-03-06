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
        public IActionResult Search(int[] selectedBasic, int page = 1, int take = 25, int id = 0)
        {
            IndexViewModel indexViewModel = GetIndexViewModel(selectedBasic,"", page, take, id);
            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult SearchResult(int[] selectedBasic, string search, int page = 1, int take = 25, int id = 0)
        {
            IndexViewModel indexViewModel = GetIndexViewModel(selectedBasic, search, page, take, id);
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
        public IActionResult Details(int[] selectImropments, int id, int page = 1, int take = 25)
        {

            IndexViewModel indexViewModel = GetIndexViewModel(selectImropments,"", page, take, id);
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
            IndexViewModel indexViewModel = GetIndexViewModel(selectedImprovments,"", page, take, id);
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

        public IndexViewModel GetIndexViewModel(int[] selectedImprovments, string search, int page = 1, int take = 25, int id = 0)
        {
            var propertyById = id <= 0 ? null : _context.Properties
               .Include(p => p.Project)
               .Include(p => p.Station)
               .Include(p => p.TypeProperties)
               .Include(p => p.Improvements).Include(p => p.FileSystemModels)
               .FirstOrDefault(m => m.PropertyId == id);

            var query = _context.Properties.Include(x => x.FileSystemModels).Include(x=>x.Improvements).AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(v => v.Name.Contains(search)).AsQueryable();
            }
            if (selectedImprovments.Count() != 0)
            {

                query = query.Where(u => selectedImprovments.Any(d => u.Improvements.Any(x => x.ImprovementId == d))).AsQueryable();

            }
            //var propertyList = query.Skip(page - 1).Take(take).ToList();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = query,
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = propertyById
            };
            return indexViewModel;
        }
    }
}
