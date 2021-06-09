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
        public PriceForSale PriceForSale { get; set; }
        public PriceForRent PriceForRent { get; set; }
        public Station Station { get; set; }
    }

    [Serializable]
    public class IndexViewModelRequest
    {
        public int[] SelectedBasic { get; set; }
        public PropertyContractType PropertyContractType { get; set; }
        public PropertyType PropertyType { get; set; }
        public BedRooms PropertyBedrooms { get; set; }
        public PriceForSale PriceForSale { get; set; }
        public PriceForRent PriceForRent { get; set; }
        public Station Station { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 25;
        public int Id { get; set; } = 0;
    }

    public enum PropertyContractType
    {
        [Display(Name = "For Rent")]
        ForRent = 0,
        [Display(Name = "For Sale")]
        ForSale = 1,
    }
    public enum PropertyType
    {
        [Display(Name = "Any")]
        Any,
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
    public enum PriceForSale
    {
        [Display(Name = "Any")]
        Any,
        [Display(Name = " < ฿2M ")]
        ForSaleRange1,
        [Display(Name = "฿2M-฿3M ")]
        ForSaleRange2,
        [Display(Name = "฿3M-฿5M ")]
        ForSaleRange3,
        [Display(Name = "฿5M-฿10M ")]
        ForSaleRange4,
        [Display(Name = "฿10M-฿14M ")]
        ForSaleRange5,
        [Display(Name = "฿15M-฿25M ")]
        ForSaleRange6,
        [Display(Name = "฿25M-฿50M ")]
        ForSaleRange7,
        [Display(Name = "฿50M-฿100M ")]
        ForSaleRange8,
        [Display(Name = ">฿100M")]
        ForSaleRange9,
    }
    public enum PriceForRent
    {
        [Display(Name = "Any")]
        Any,
        [Display(Name = "< ฿9,999")]
        ForRentRange1,
        [Display(Name = "฿10,000-฿24,999")]
        ForRentRange2,
        [Display(Name = "฿25,000-฿34,999")]
        ForRentRange3,
        [Display(Name = "฿35,000-฿49,999")]
        ForRentRange4,
        [Display(Name = "฿50,000-฿74,999")]
        ForRentRange5,
        [Display(Name = "฿75,000-฿99,999")]
        ForRentRange6,
        [Display(Name = "฿100,000-฿149,999")]
        ForRentRange7,
        [Display(Name = ">฿150,000")]
        ForRentRange8
    }
}
