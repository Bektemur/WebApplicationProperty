using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        const double constForSale = 1000000;
        const double constForRent = 1000;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Search(int page = 1, int take = 25, int id = 0)
        {
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            IndexViewModel indexViewModel = await GetIndexViewModel(page, take, id);
            return View(indexViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SearchResult(IndexViewModelRequest model)
        {
            IndexViewModel indexViewModel = await GetIndexViewModel(model.SelectedBasic, model.PropertyContractType, model.PropertyType,
                model.PropertyBedrooms, model.PriceForRent, model.PriceForSale, model.Search, model.Page, model.Take, model.Id);
            return PartialView("_PropertySearchPartial", indexViewModel);
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = _context.Properties.Include(x => x.FileSystemModels).Skip(0).Take(3).ToList()
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
        public async Task<IndexViewModel> GetIndexViewModel(int page = 1, int take = 25, int id = 0)
        {
            var propertyById = id <= 0 ? null : _context.Properties
               .Include(p => p.Project)
               .Include(p => p.Station)
               .Include(p => p.TypeProperties)
               .Include(p => p.Improvements).Include(p => p.FileSystemModels)
               .FirstOrDefault(m => m.PropertyId == id);
            var query = _context.Properties.Include(x => x.FileSystemModels).Include(x => x.Improvements).AsQueryable();
            var propertyList = await query.Skip((page - 1) * take).Take(take).ToListAsync();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = propertyList,
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = propertyById,

            };
            return indexViewModel;
        }

        public async Task<IndexViewModel> GetIndexViewModel(int[] selectedImprovments, PropertyContractType propertyContractType, PropertyType propertyType, BedRooms BedRooms, PriceForRent priceForRent, PriceForSale priceForSale, string search, int page = 1, int take = 25, int id = 0)
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
                query = query.Where(v => v.Name.Contains(search) || v.Street.Contains(search)).AsQueryable();
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
            if (propertyType != PropertyType.Any)
            {
                query = query.Where(c => c.TypeProperties.Name == Enum.GetName(typeof(PropertyType), propertyType));
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
            if (BedRooms == BedRooms.Beds4)
            {
                query = query.Where(c => c.Bedrooms == 4);
            }
            PriceRangeForSale(priceForSale, out double minvalueForSale, out double maxvalueForSale);
            if (propertyContractType == PropertyContractType.ForSale)
            {
                query = query.Where(c => c.PriceRent <= maxvalueForSale && c.PriceRent >= minvalueForSale);
            }
            PriceRangeForRent(priceForRent, out double minvalueForRent, out double maxvalueForRent);
            if (propertyContractType == PropertyContractType.ForRent)
            {
                query = query.Where(c => c.PriceRent <= maxvalueForRent && c.PriceRent >= minvalueForRent);
            }
            var propertyList = await query.Skip((page - 1) * take).Take(take).ToListAsync();

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                ListProperty = propertyList,
                Improvements = _context.Improvements.ToList(),
                Page = page,
                Take = take,
                Property = propertyById,
                PriceForRent = priceForRent,
                PriceForSale = priceForSale,
                PropertyContractType = propertyContractType
            };
            return indexViewModel;
        }
        public void PriceRangeForSale(PriceForSale priceForSale, out double minimumPriceForSale, out double maximumPriceForSale)
        {
            switch (priceForSale)
            {
                case PriceForSale.ForSaleRange1:
                    minimumPriceForSale = 0;
                    maximumPriceForSale = 2 * constForSale;
                    break;
                case PriceForSale.ForSaleRange2:
                    minimumPriceForSale = 2 * constForSale;
                    maximumPriceForSale = 3 * constForSale;
                    break;
                case PriceForSale.ForSaleRange3:
                    minimumPriceForSale = 3 * constForSale;
                    maximumPriceForSale = 5 * constForSale;
                    break;
                case PriceForSale.ForSaleRange4:
                    minimumPriceForSale = 5 * constForSale;
                    maximumPriceForSale = 10 * constForSale;
                    break;
                case PriceForSale.ForSaleRange5:
                    minimumPriceForSale = 10 * constForSale;
                    maximumPriceForSale = 14 * constForSale;
                    break;
                case PriceForSale.ForSaleRange6:
                    minimumPriceForSale = 14 * constForSale;
                    maximumPriceForSale = 25 * constForSale;
                    break;
                case PriceForSale.ForSaleRange7:
                    minimumPriceForSale = 25 * constForSale;
                    maximumPriceForSale = 50 * constForSale;
                    break;
                case PriceForSale.ForSaleRange8:
                    minimumPriceForSale = 50 * constForSale;
                    maximumPriceForSale = 100 * constForSale;
                    break;
                case PriceForSale.ForSaleRange9:
                    minimumPriceForSale = 100 * constForSale;
                    maximumPriceForSale = 1000 * constForSale;
                    break;
                default:
                    minimumPriceForSale = 0;
                    maximumPriceForSale = 100 * constForSale;
                    break;
            }
        }
        public void PriceRangeForRent(PriceForRent priceForRent, out double minimumPriceForRent, out double maximumPriceForRent)
        {
            switch (priceForRent)
            {
                case PriceForRent.ForRentRange1:
                    minimumPriceForRent = 0;
                    maximumPriceForRent = 9.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange2:
                    minimumPriceForRent = 10 * constForRent;
                    maximumPriceForRent = 24.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange3:
                    minimumPriceForRent = 25 * constForRent;
                    maximumPriceForRent = 34.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange4:
                    minimumPriceForRent = 35 * constForRent;
                    maximumPriceForRent = 49.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange5:
                    minimumPriceForRent = 50 * constForRent;
                    maximumPriceForRent = 74.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange6:
                    minimumPriceForRent = 75 * constForRent;
                    maximumPriceForRent = 99.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange7:
                    minimumPriceForRent = 100 * constForRent;
                    maximumPriceForRent = 149.999 * constForRent;
                    break;
                case PriceForRent.ForRentRange8:
                    minimumPriceForRent = 150 * constForRent;
                    maximumPriceForRent = 999.999 * constForRent;
                    break;
                default:
                    minimumPriceForRent = 0;
                    maximumPriceForRent = 999.999 * constForRent;
                    break;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Callback(CallbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Callbacks.Add(new CallbackModel()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    Message = model.Message,
                    PropertyId = model.PropertyId
                });
                _context.SaveChanges();

                return PartialView("_Callback", new CallbackViewModel()
                {
                    Id = entity.Entity.Id,
                    PropertyId = model.PropertyId
                });
            }
            model.Id = 0;
            return PartialView("_Callback", model);
        }
    }
}
