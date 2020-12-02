using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index(int page = 1, int take = 25 , int id = 0)
        {
            var applicationDbContext = _context.Properties.Include(p => p.User).Include(p => p.Project).Include(p => p.Station).Include(p => p.TypeProperties);
            
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
            //ViewData["getRelative"] = date;
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
        public IActionResult Details(int? id, int page = 1, int take = 25)
        {
            if (id == null)
            {
                return NotFound();
            }

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
               .Include(p => p.Improvements).Include(p => p.FileSystemModels)
               .FirstOrDefault(m => m.PropertyId == id)
            };
            if (indexViewModel == null)
            {
                return NotFound();
            }

            return View(indexViewModel);
        }
    }
}
