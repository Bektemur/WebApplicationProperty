using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Other
    {
        [Key]
        public int OtherId { get; set; }
        public string Name { get; set; }
        public List<OtherProperties> OtherProperties { get; set; }
        public Other()
        {
            OtherProperties = new List<OtherProperties>();
        }
    }
    public class OtherProperties
    {
        public int OtherId { get; set; }
        public Other Other { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
