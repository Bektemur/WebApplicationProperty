using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable <Property> Property { get; set; }
        public IEnumerable<FileOnFileSystemModel> FileSystemModels { get; set; }
        public string UpdateDate { get; set; }
        public string PublicDate { get; set; }
    }
}
