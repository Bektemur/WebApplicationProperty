using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Extra
    {
        [Key]
        public int ExtraId { get; set; }
        public string Name { get; set; }
        public List<ExtraProperies> ExtraProperies { get; set; }
        public Extra()
        {
            ExtraProperies = new List<ExtraProperies>();
        }
    }
    public class ExtraProperies
    {
        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
