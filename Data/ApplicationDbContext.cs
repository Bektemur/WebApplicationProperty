using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeProperty>().HasData(new TypeProperty() { TypePropertyId = 1, Name = "Unspecified" }, 
                new TypeProperty() { TypePropertyId = 2, Name = "Townhouse" },
                new TypeProperty() { TypePropertyId = 3, Name = "House" },
                new TypeProperty() { TypePropertyId = 4, Name = "Condominium" },
                new TypeProperty() { TypePropertyId = 5, Name = "Appartment" },
                new TypeProperty() { TypePropertyId = 6, Name = "Office" },
                new TypeProperty() { TypePropertyId = 7, Name = "Land" },
                new TypeProperty() { TypePropertyId = 8, Name = "Penthouse" },
                new TypeProperty() { TypePropertyId = 9, Name = "Serviced Apartment" },
                new TypeProperty() { TypePropertyId = 10, Name = "Shop house" },
                new TypeProperty() { TypePropertyId = 11, Name = "Retail" },
                new TypeProperty() { TypePropertyId = 12, Name = "Business" },
                new TypeProperty() { TypePropertyId = 13, Name = "Factory" },
                new TypeProperty() { TypePropertyId = 14, Name = "Commercial Building" },
                new TypeProperty() { TypePropertyId = 15, Name = "Hotel / Resort" },
                new TypeProperty() { TypePropertyId = 16, Name = "Other Commertcial" });
            modelBuilder.Entity<Improvement>().HasData(
                new Improvement() { Id = 1 , Name = "Parking", Type = ImprovementType.Facilities },
                new Improvement() { Id = 2, Name = "TV", Type = ImprovementType.Facilities },
                new Improvement() { Id = 3, Name = "Refrigerator", Type = ImprovementType.Facilities },
                new Improvement() { Id = 4, Name = "Washing Machine", Type = ImprovementType.Facilities },
                new Improvement() { Id = 5, Name = "Kitchen", Type = ImprovementType.Facilities },
                new Improvement() { Id = 6, Name = "Balcony", Type = ImprovementType.Facilities },
                new Improvement() { Id = 7, Name = "Internet", Type = ImprovementType.Facilities },
                new Improvement() { Id = 8, Name = "Drying Machine", Type = ImprovementType.Facilities },
                new Improvement() { Id = 9, Name = "Private garden", Type = ImprovementType.Facilities },
                new Improvement() { Id = 10, Name = "Roof Terrace", Type = ImprovementType.Facilities },
                new Improvement() { Id = 11, Name = "Open kitchen", Type = ImprovementType.Facilities },
                new Improvement() { Id = 12, Name = "Cooker Hob & Hood", Type = ImprovementType.Facilities },
                new Improvement() { Id = 13, Name = "Closed kitchen", Type = ImprovementType.Facilities },
                new Improvement() { Id = 14, Name = "Water Heater", Type = ImprovementType.Facilities },
                new Improvement() { Id = 15, Name = "Common garden", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 16, Name = "Function Room", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 17, Name = "Common jacuzzi", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 18, Name = "Lounge", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 19, Name = "Restaurant", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 20, Name = "Building security", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 21, Name = "Garage", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 22, Name = "Onsen Spa", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 23, Name = "Sauna", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 24, Name = "Cafe", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 25, Name = "Gym/Fitness", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 26, Name = "Library", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 27, Name = "Outdoor swimming pool", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 28, Name = "Spa", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 29, Name = "Children playroom", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 30, Name = "Indoor swimming pool", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 31, Name = "Lift", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 32, Name = "Playground", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 33, Name = "Steamroom", Type = ImprovementType.CommonArea },
                new Improvement() { Id = 34, Name = "European", Type = ImprovementType.Interior },
                new Improvement() { Id = 35, Name = "Industrial", Type = ImprovementType.Interior },
                new Improvement() { Id = 36, Name = "Minimalistic", Type = ImprovementType.Interior },
                new Improvement() { Id = 37, Name = "Modern", Type = ImprovementType.Interior },
                new Improvement() { Id = 38, Name = "Thai", Type = ImprovementType.Interior },
                new Improvement() { Id = 39, Name = "Not Decorated", Type = ImprovementType.Interior },
                new Improvement() { Id = 40, Name = "Air Conditioning", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 41, Name = "Bathtub", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 42, Name = "Oven", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 43, Name = "Cooking gas", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 44, Name = "Private Pool", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 45, Name = "Fan", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 46, Name = "Stove", Type = ImprovementType.Fixtures },
                new Improvement() { Id = 47, Name = "Goverment electricity meter", Type = ImprovementType.Other },
                new Improvement() { Id = 48, Name = "Shopping Mall", Type = ImprovementType.Other },
                new Improvement() { Id = 49, Name = "Public water meter", Type = ImprovementType.Other },
                new Improvement() { Id = 50, Name = "Golf Simulator", Type = ImprovementType.Other },
                new Improvement() { Id = 51, Name = "Co-Working Space", Type = ImprovementType.Other },
                new Improvement() { Id = 52, Name = "Cleaning service", Type = ImprovementType.Other },
                new Improvement() { Id = 53, Name = "Mini Market", Type = ImprovementType.Other },
                new Improvement() { Id = 54, Name = "Mini Market", Type = ImprovementType.Other },
                new Improvement() { Id = 55, Name = "Wheelchair accessible", Type = ImprovementType.Extra },
                new Improvement() { Id = 56, Name = "Badminton Court", Type = ImprovementType.Extra },
                new Improvement() { Id = 57, Name = "Company Registration", Type = ImprovementType.Extra },
                new Improvement() { Id = 58, Name = "High Floor", Type = ImprovementType.Extra },
                new Improvement() { Id = 59, Name = "Low Floor", Type = ImprovementType.Extra },
                new Improvement() { Id = 60, Name = "Scenic View", Type = ImprovementType.Extra },
                new Improvement() { Id = 61, Name = "BBQ Area", Type = ImprovementType.Extra },
                new Improvement() { Id = 62, Name = "New Project", Type = ImprovementType.Extra },
                new Improvement() { Id = 63, Name = "Pool View", Type = ImprovementType.Extra },
                new Improvement() { Id = 64, Name = "Sea View", Type = ImprovementType.Extra },
                new Improvement() { Id = 65, Name = "Allows Pets", Type = ImprovementType.Extra },
                new Improvement() { Id = 66, Name = "Shuttle service", Type = ImprovementType.Extra },
                new Improvement() { Id = 67, Name = "Jogging Track", Type = ImprovementType.Extra },
                new Improvement() { Id = 68, Name = "Luxury", Type = ImprovementType.Extra },
                new Improvement() { Id = 69, Name = "Park View", Type = ImprovementType.Extra },
                new Improvement() { Id = 70, Name = "Rent Guarantee", Type = ImprovementType.Extra },
                new Improvement() { Id = 71, Name = "Allow Short-term", Type = ImprovementType.Extra },
                new Improvement() { Id = 72, Name = "City View", Type = ImprovementType.Extra },
                new Improvement() { Id = 73, Name = "Lake View", Type = ImprovementType.Extra },
                new Improvement() { Id = 74, Name = "Maid's Room", Type = ImprovementType.Extra },
                new Improvement() { Id = 75, Name = "Penthouse", Type = ImprovementType.Extra },
                new Improvement() { Id = 76, Name = "Partially Furnished", Type = ImprovementType.Basic },
                new Improvement() { Id = 77, Name = "Fully Furnished", Type = ImprovementType.Basic },
                new Improvement() { Id = 78, Name = "Needs renovation", Type = ImprovementType.Basic },
                new Improvement() { Id = 79, Name = "Renovated", Type = ImprovementType.Basic },
                new Improvement() { Id = 80, Name = "To be renovated", Type = ImprovementType.Basic },
                new Improvement() { Id = 81, Name = "Unfurnished", Type = ImprovementType.Basic }
                );
            modelBuilder.Entity<Project>().HasMany(c => c.Properties).WithOne(e => e.Project);
            modelBuilder.Entity<Station>().HasMany(c => c.Properties).WithOne(e => e.Station);
            modelBuilder.Entity<TypeProperty>().HasMany(c => c.Properties).WithOne(e => e.TypeProperties);
            modelBuilder.Entity<ApplicationUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
        public DbSet<Improvement> Improvements { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }

    }
}
