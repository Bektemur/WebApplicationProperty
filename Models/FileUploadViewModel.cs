using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class FileUploadViewModel
    {
        public List<FileOnFileSystemModel> FileOnFileSystem { get; set; }
        public int PropertyId { get; set; }
    }
}
