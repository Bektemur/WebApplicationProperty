using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationProperty.Data;

namespace WebApplicationProperty.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public double Price { get; set; }
        public double Price_sqm { get; set; }
        public double Price_rent { get; set; }
        public double Living_area { get; set; }
        public double Land_area { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Parking { get; set; }
        public DateTime Public_date { get; set; }
        public DateTime Update_date { get; set; }
        public bool ForRent { get; set; }
        public bool ForSale { get; set; }
        public int TypePropertyId { get; set; }
        [ForeignKey("TypePropertyId")]
        public TypeProperty TypeProperties { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public int StationId { get; set; }
        [ForeignKey("StationId")]
        public Station Station { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }
        public virtual ICollection<FileOnFileSystemModel> FileSystemModels { get; set; }
        public virtual ICollection<ImprovementToProperty> Improvements { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
