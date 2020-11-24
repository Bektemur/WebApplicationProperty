using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class CommonArea
    {
        [Key]
        public int CommonAreaId { get; set; }
        public string Name { get; set; }
        public virtual List<CommonAreaProperties> CommonAreaProperties { get; set; }
    }
    public class CommonAreaProperties
    {
        public int CommonAreaId { get; set; }
        public CommonArea CommonArea { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
