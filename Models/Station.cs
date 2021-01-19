using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<Property> Properties { get; set; }
    }
    public enum StationType
    {
        BTS = 0,
        MRT = 1,
    }
}