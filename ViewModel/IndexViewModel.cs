using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.ViewModel
{
    public class IndexViewModel
    {
        public int Page { get; set; }
        public int Take { get; set; }
        public IEnumerable <Property> ListProperty { get; set; }
        public IEnumerable<Improvement> Improvements { get; set; }
        public Property Property { get; set; }
        public string UpdateDate { get; set; }
        public string PublicDate { get; set; }
    }
}
