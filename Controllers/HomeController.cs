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
            IndexViewModel indexViewModel = await GetIndexViewModel(selectedBasic, 0, 0, 0, 0, 0, "", page, take, id);
            return View(indexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> SearchResult(IndexViewModelRequest model)
        {
            IndexViewModel indexViewModel = await GetIndexViewModel(model.SelectedBasic, model.PropertyContractType, model.PropertyType,
                model.propertyBedrooms, model.minvalue, model.maxvalue, model.search, model.page, model.take, model.id);
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
            IndexViewModel indexViewModel = await GetIndexViewModel(selectImropments, 0, 0, 0, 0, 0, "", page, take, id);
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
            IndexViewModel indexViewModel = await GetIndexViewModel(selectedImprovments, 0, 0, 0, 0, 0, "", page, take, id);
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


        public async Task<IndexViewModel> GetIndexViewModel(int[] selectedImprovments, PropertyContractType propertyContractType,  PropertyType propertyType, BedRooms BedRooms,  double minvalue, double maxvalue, string search, int page = 1, int take = 25, int id = 0)
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
            if (selectedImprovments != null && selectedImprovments.Length > 0)
            {
                query = query.Where(u => u.Improvements.Any(x => selectedImprovments.Contains(x.ImprovementId))).AsQueryable();
            }
            if (propertyContractType == PropertyContractType.ForRent)
            {
                query = query.Where(c => c.ForRent);
            }
            if (propertyContractType == PropertyContractType.ForSale)
            {
                query = query.Where(c => c.ForSale);
            }
            if (propertyType == PropertyType.Appartment)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Appartment.ToString());
            }
            if (propertyType == PropertyType.Business)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Business.ToString());
            }
            if (propertyType == PropertyType.CommercialBuilding)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.CommercialBuilding.ToString());
            }
            if (propertyType == PropertyType.Factory)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Factory.ToString());
            }
            if (propertyType == PropertyType.Condominium)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Condominium.ToString());
            }
            if (propertyType == PropertyType.HotelResort)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.HotelResort.ToString());
            }
            if (propertyType == PropertyType.House)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.House.ToString());
            }
            if (propertyType == PropertyType.Land)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Land.ToString());
            }
            if (propertyType == PropertyType.OtherCommertcial)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.OtherCommertcial.ToString());
            }
            if (propertyType == PropertyType.Penthouse)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Penthouse.ToString());
            }
            if (propertyType == PropertyType.HotelResort)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.HotelResort.ToString());
            }
            if (propertyType == PropertyType.Retail)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Retail.ToString());
            }
            if (propertyType == PropertyType.ShopHouse)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.ShopHouse.ToString());
            }
            if (propertyType == PropertyType.ServicedApartment)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.ServicedApartment.ToString());
            }
            if (propertyType == PropertyType.Office)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Office.ToString());
            }
            if (propertyType == PropertyType.Unspecified)
            {
                query = query.Where(c => c.TypeProperties.Name == PropertyType.Unspecified.ToString());
            }
            if (BedRooms == BedRooms.Beds1)
            {
                query = query.Where(c => c.Bedrooms == 1);
            }
            if (BedRooms == BedRooms.Beds2)
            {
                query = query.Where(c => c.Bedrooms == 2);
            }
            if (BedRooms == BedRooms.Beds3)
            {
                query = query.Where(c => c.Bedrooms == 3);
            }
            if (maxvalue > 0 && minvalue > 0 && propertyContractType == PropertyContractType.ForRent)
            {
                query = query.Where(c => c.Price_rent <= maxvalue && c.Price_rent >= minvalue);
            }
            if (maxvalue > 0 && minvalue > 0)
            {
                query = query.Where(c => c.Price <= maxvalue && c.Price >= minvalue);
            }
            var propertyList = await query.Skip((page - 1) * take).Take(take).ToListAsync();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = propertyList,
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = propertyById,
                PropertyContractType = propertyContractType
            };
            return indexViewModel;
        }
    }
}
