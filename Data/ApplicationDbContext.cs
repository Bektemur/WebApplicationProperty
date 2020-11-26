using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasMany(c => c.Properties).WithOne(e => e.Project);
            modelBuilder.Entity<Station>().HasMany(c => c.Properties).WithOne(e => e.Station);
            modelBuilder.Entity<TypeProperty>().HasMany(c => c.Properties).WithOne(e => e.TypeProperties);
            modelBuilder.Entity<ExtraProperies>().HasKey(t => new { t.ExtraId, t.PropertiesId });
            modelBuilder.Entity<ExtraProperies>()
            .HasOne(sc => sc.Extra)
            .WithMany(s => s.ExtraProperies)
            .HasForeignKey(sc => sc.ExtraId);

            modelBuilder.Entity<ExtraProperies>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.ExtraProperies)
                .HasForeignKey(sc => sc.PropertiesId);

            modelBuilder.Entity<FacilitiesProperty>().HasKey(t => new { t.FacilitiesId, t.PropertyId });
            modelBuilder.Entity<FacilitiesProperty>()
            .HasOne(sc => sc.Facilities)
            .WithMany(s => s.FacilitiesProperties)
            .HasForeignKey(sc => sc.FacilitiesId);

            modelBuilder.Entity<FacilitiesProperty>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.FacilitiesProperties)
                .HasForeignKey(sc => sc.PropertyId);

            modelBuilder.Entity<FixturesProperty>().HasKey(t => new { t.FixturesId, t.PropertiesId });
            modelBuilder.Entity<FixturesProperty>()
            .HasOne(sc => sc.Fixtures)
            .WithMany(s => s.FixturesProperties)
            .HasForeignKey(sc => sc.FixturesId);

            modelBuilder.Entity<FixturesProperty>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.FixturesProperties)
                .HasForeignKey(sc => sc.PropertiesId);


            modelBuilder.Entity<InteriorProperties>().HasKey(t => new { t.InteriorId, t.PropertiesId });
            modelBuilder.Entity<InteriorProperties>()
            .HasOne(sc => sc.Interior)
            .WithMany(s => s.InteriorProperties)
            .HasForeignKey(sc => sc.InteriorId);

            modelBuilder.Entity<InteriorProperties>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.InteriorProperties)
                .HasForeignKey(sc => sc.PropertiesId);

            modelBuilder.Entity<OtherProperties>().HasKey(t => new { t.OtherId, t.PropertiesId });
            modelBuilder.Entity<OtherProperties>()
            .HasOne(sc => sc.Other)
            .WithMany(s => s.OtherProperties)
            .HasForeignKey(sc => sc.OtherId);

            modelBuilder.Entity<OtherProperties>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.OtherProperties)
                .HasForeignKey(sc => sc.PropertiesId);
  

            modelBuilder.Entity<BasicProperties>().HasKey(t => new { t.BasicId, t.PropertiesId });
            modelBuilder.Entity<BasicProperties>()
            .HasOne(sc => sc.Basic)
            .WithMany(s => s.BasicProperties)
            .HasForeignKey(sc => sc.BasicId);

            modelBuilder.Entity<BasicProperties>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.BasicProperties)
                .HasForeignKey(sc => sc.PropertiesId);

            modelBuilder.Entity<CommonAreaProperties>().HasKey(t => new { t.CommonAreaId, t.PropertiesId });
            modelBuilder.Entity<CommonAreaProperties>()
            .HasOne(sc => sc.CommonArea)
            .WithMany(s => s.CommonAreaProperties)
            .HasForeignKey(sc => sc.CommonAreaId);

            modelBuilder.Entity<CommonAreaProperties>()
                .HasOne(sc => sc.Properties)
                .WithMany(c => c.CommonAreaProperties)
                .HasForeignKey(sc => sc.PropertiesId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Basic> Basics { get; set; }
        public DbSet<CommonArea> CommonAreas { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Fixtures> Fixtures { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<CommonAreaProperties> CommonAreaProperties { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
    }
}
