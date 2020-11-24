using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Properties
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Price_sqm { get; set; }
        public double Living_area { get; set; }
        public double Land_area { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Parking { get; set; }
        public DateTime Public_date { get; set; }
        public DateTime Update_date { get; set; }
        [ForeignKey("TypePropertyId")]
        public int TypePropertyId { get; set; }
        public TypeProperty TypeProperties { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [ForeignKey("StationId")]
        public int StationId { get; set; }
        public Station Station { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual List<ExtraProperies> ExtraProperies { get; set; }
        public virtual List<FacilitiesProperty> FacilitiesProperties { get; set; }
        public virtual List<FixturesProperty> FixturesProperties { get; set; }
        public virtual List<InteriorProperties> InteriorProperties { get; set; }
        public virtual List<OtherProperties> OtherProperties { get; set; }
        public virtual List<BasicProperties> BasicProperties { get; set; }
        public virtual List<CommonAreaProperties> CommonAreaProperties { get; set; }
    }
}
