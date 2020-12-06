using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Data;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel;

namespace WebApplicationProperty.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileController> _logger;
        public FileController(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = loggerFactory.CreateLogger<FileController>();
        }

        public IActionResult Index(int page = 1, int take = 25, int id = 0)
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
            return View(indexViewModel);
        }
        public async Task<IActionResult> Create()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            ViewData["PropertyId"] = new SelectList(_context.Properties.Where(v=>v.FileSystemModels.Count == 0).ToList(), "PropertyId", "Name");
            return View(fileuploadViewModel);
        }
        private async Task<Models.FileUploadViewModel> LoadAllFiles()
        {
            // move This Method for a Service Layer
            var viewModel = new Models.FileUploadViewModel();
            viewModel.FileOnFileSystem = await _context.FilesOnFileSystem.ToListAsync();
            return viewModel;
        }
        private async Task<Models.FileUploadViewModel> LoadAllFilesofProperty(int? id)
        {
            // move This Method for a Service Layer
            var viewModel = new Models.FileUploadViewModel();
            viewModel.FileOnFileSystem = await _context.FilesOnFileSystem.Where(v=>v.PropertyId == id).ToListAsync();
            return viewModel;
        }
        public async Task<ActionResult> Edit(int? id)
        {
            var fileuploadViewModel = await LoadAllFilesofProperty(id);
            ViewBag.Message = TempData["Message"];
            ViewData["PropertyId"] = new SelectList(_context.Properties.Where(v => v.PropertyId == id).ToList(), "PropertyId", "Name");
            return View(fileuploadViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files, int propertyid)
        {
            var propertyName = _context.Properties.Where(v => v.PropertyId == propertyid).Select(v => v.Name).FirstOrDefault();
            foreach (var file in files)
            {
                var dateTime = DateTime.UtcNow;
                var internalFolder = Path.Combine("images", "Property", dateTime.Year.ToString(), dateTime.Month.ToString(), dateTime.Day.ToString());
                var basePath = Path.Combine(_webHostEnvironment.WebRootPath, internalFolder);
                if (!Directory.Exists(basePath)) { Directory.CreateDirectory(basePath); }
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);
                var filePath = Path.Combine(basePath, fileName + extension);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    _logger.LogInformation($"{nameof(UploadToFileSystem)} {fileName} saved");
                }

                var fileModel = new FileOnFileSystemModel
                {
                    CreatedOn = dateTime,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = file.FileName,
                    PropertyId = propertyid,
                    PropertyName = propertyName,
                    FilePath = Path.Combine(internalFolder, fileName + extension)
                };
                _context.FilesOnFileSystem.Add(fileModel);
                _context.SaveChanges();

            }
            TempData["Message"] = "File successfully uploaded to File System";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        {
            var file = await _context.FilesOnFileSystem.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) { return null; }
            return File(file.FilePath, file.FileType, file.Name + file.Extension);
        }

        public async Task<IActionResult> DeleteFileFromFileSystem(int id)
        {
            var file = await _context.FilesOnFileSystem.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            else
            {
                _logger.LogInformation($"{nameof(DeleteFileFromFileSystem)} file {id} not exists {file.FilePath}");
            }
            _context.FilesOnFileSystem.Remove(file);
            _context.SaveChanges();
            TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from File System";
            return RedirectToAction("Index");
        }
    }
}
