using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProperty.Models
{
    public class Station
    {
        [Key]
        public int StationId { get; set; }
        public string Name { get; set; }
        public StationType StationType { get; set; }
        public string PlaceName { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
    public enum StationType
    {
        BTS = 0,
        MRT = 1,
    }
}