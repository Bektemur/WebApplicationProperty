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

            modelBuilder.Entity<Project>().HasMany(c => c.Properties).WithOne(e => e.Project);
            modelBuilder.Entity<Station>().HasMany(c => c.Properties).WithOne(e => e.Station);
            modelBuilder.Entity<TypeProperty>().HasMany(c => c.Properties).WithOne(e => e.TypeProperties);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
        public DbSet<Improvement> Improvements { get; set; }
    }
}
