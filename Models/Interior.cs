using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Interior
    {
        [Key]
        public int InteriorId { get; set; }
        public string Name { get; set; }
        public virtual List<InteriorProperties> InteriorProperties { get; set; }
        
    }
    public class InteriorProperties
    {
        public int InteriorId { get; set; }
        public Interior Interior { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
