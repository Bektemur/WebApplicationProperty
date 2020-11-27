using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProperty.Models
{
    public class TypeProperty
    {
        [Key]
        public int TypePropertyId { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }
}