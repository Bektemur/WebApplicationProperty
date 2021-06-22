using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Controllers
{
    public class ExcelController : Controller
    {
        public ExcelController() { }

        public IActionResult Index()
        {
            return View(new Dictionary<int, List<string>>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromServices] IWebHostEnvironment appEnvironment, IFormFileCollection uploads)
        {
            var result = new Dictionary<int, List<string>>();
            foreach (var uploadedFile in uploads)
            {
                if (uploadedFile.FileName.EndsWith(".xlsx"))
                {
                    string path = Path.Combine(appEnvironment.WebRootPath, "TempFiles", uploadedFile.FileName);
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    }
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(new FileInfo(path)))
                    {
                        var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                        var start = workSheet.Dimension.Start;
                        var end = workSheet.Dimension.End;
                        for (int row = start.Row; row <= end.Row; row++)
                        {
                            var list = new List<string>();
                            for (int col = start.Column; col <= end.Column; col++)
                            {
                                list.Add(workSheet.Cells[row, col]?.Value?.ToString() ?? string.Empty);
                            }
                            result.Add(row, list);
                        }
                    }
                }
            }
            return View(result);
        }
    }
}
