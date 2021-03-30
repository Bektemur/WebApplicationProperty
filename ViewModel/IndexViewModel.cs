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
        public IEnumerable<Property> ListProperty { get; set; }
        public IEnumerable<Improvement> Improvements { get; set; }
        public Property Property { get; set; }
        public PropertyContractType PropertyContractType { get; set; }
    }

    [Serializable]
    public class IndexViewModelRequest
    {
        public int[] SelectedBasic { get; set; }
        public PropertyContractType PropertyContractType { get; set; }
        public string propertyTypes { get; set; }
        public int propertyBedrooms { get; set; }
        public double minvalue { get; set; }
        public double maxvalue { get; set; }
        public string search { get; set; }
        public int page { get; set; } = 1;
        public int take { get; set; } = 25;
        public int id { get; set; } = 0;
    }

    public enum PropertyContractType
    {
        Any = 0,
        ForRent = 1,
        ForSale = 2,
        ForSaleOrRent = 3,
    }
}
