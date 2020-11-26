using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
