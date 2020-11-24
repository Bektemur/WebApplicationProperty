using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Fixtures
    {
        [Key]
        public int FixturesId { get; set; }
        public string Name { get; set; }
        public List<FixturesProperty> FixturesProperties { get; set; }
        public Fixtures()
        {
            FixturesProperties = new List<FixturesProperty>();
        }
    }
    public class FixturesProperty
    {
        public int FixturesId { get; set; }
        public Fixtures Fixtures { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
