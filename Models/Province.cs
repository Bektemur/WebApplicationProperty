using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        [ForeignKey("StationId")]
        public int StationId { get; set; }
        public Station Station { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
