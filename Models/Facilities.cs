using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Facilities
    {
        [Key]
        public int FacilitiesId { get; set; }
        public string Name { get; set; }
        public virtual List<FacilitiesProperty> FacilitiesProperties { get; set; }
        public Facilities()
        {
            FacilitiesProperties = new List<FacilitiesProperty>();
        }
    }
    public class FacilitiesProperty
    {
        public int FacilitiesId { get; set; }
        public Facilities Facilities { get; set; }
        public int PropertyId { get; set; }
        public Properties Properties { get; set; }
    }
}
