using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Improvements
    {
        public int Id { get; set; }
        public ImprovementType Type { get; set; }
        public string Name { get; set; }
    }
    public enum ImprovementType
    {
        None = 0,
        Basic = 1,
        Facilities = 2,
        Interior = 3,
        Fixtures = 4,
        CommonArea = 5,
        Extra = 6,
        Other = 7,
        Station = 8,
        Project = 9
    }
}
