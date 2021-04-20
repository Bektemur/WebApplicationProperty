using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public PropertyType PropertyType { get; set; }
        public BedRooms Bedrooms { get; set; }
    }

    [Serializable]
    public class IndexViewModelRequest
    {
        public int[] SelectedBasic { get; set; }
        public PropertyContractType PropertyContractType { get; set; }
        public PropertyType PropertyType {get; set;}
        public BedRooms propertyBedrooms { get; set; }
        public double minvalue { get; set; }
        public double maxvalue { get; set; }
        public string search { get; set; }
        public int page { get; set; } = 1;
        public int take { get; set; } = 25;
        public int id { get; set; } = 0;
    }

    public enum PropertyContractType
    {
        [Display(Name = "Any")]
        Any = 0,
        [Display(Name = "For rent")]
        ForRent = 1,
        [Display(Name = "For sale")]
        ForSale = 2,
        [Display(Name = "For rent or sale")]
        ForSaleOrRent = 3,
    }
    public enum PropertyType
    {
        [Display(Name = "Unspecified")]
        Unspecified,
        [Display(Name = "Townhouse")]
        Townhouse,
        [Display(Name = "House")]
        House,
        [Display(Name = "Condominium")]
        Condominium,
        [Display(Name = "Appartment")]
        Appartment,
        [Display(Name = "Office")]
        Office,
        [Display(Name = "Land")]
        Land,
        [Display(Name = "Penthouse")]
        Penthouse,
        [Display(Name = "Serviced Apartment")]
        ServicedApartment,
        [Display(Name = "Shop house")]
        ShopHouse,
        [Display(Name = "Retail")]
        Retail,
        [Display(Name = "Business")]
        Business,
        [Display(Name = "Factory")]
        Factory,
        [Display(Name = "Commercial Building")]
        CommercialBuilding,
        [Display(Name = "Hotel Resort")]
        HotelResort,
        [Display(Name = "Other Commertcial")]
        OtherCommertcial
    }
    public enum BedRooms
    {
        Any,
        [Display(Name = "1+ Beds")]
        Beds1,
        [Display(Name = "2+ Beds")]
        Beds2,
        [Display(Name = "3+ Beds")]
        Beds3,
        [Display(Name = "4+ Beds")]
        Beds4
    }
}
