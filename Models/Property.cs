﻿using Microsoft.AspNetCore.Http;
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

        public bool ForRent { get; set; }
        public bool ForSale { get; set; }
        public double PriceSale { get; set; }
        public double PriceSaleSqm { get; set; }
        public double PriceRent { get; set; }

        public double LivingArea { get; set; }
        public double LandArea { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Parking { get; set; }

        public DateTime PublicDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ApplicationUserId { get; set; }

        public int TypePropertyId { get; set; }
        public int? ProjectId { get; set; }
        public int? StationId { get; set; }
        public int? CityId { get; set; }

        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [ForeignKey("TypePropertyId")]
        public virtual TypeProperty TypeProperties { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<FileOnFileSystemModel> FileSystemModels { get; set; }
        public virtual ICollection<ImprovementToProperty> Improvements { get; set; }
    }
}
