using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProperty.Models
{
    public class Station
    {
        [Key]
        public int StationId { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }
}