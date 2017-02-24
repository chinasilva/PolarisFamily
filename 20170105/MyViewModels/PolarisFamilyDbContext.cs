using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Web.Models.MyViewModels
{
    public class PolarisFamilyDbContext:IdentityDbContext<IdentityUser>
    {
        public PolarisFamilyDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建Models
            builder.Entity<Product>().HasKey(b=>b.ProductID);
            builder.Entity<ProductImage>().HasKey(c => c.ImageID);
            //builder.Entity<ApplicationUser>().HasKey(d => d.Id);
            builder.Entity<Brand>().HasKey(b => b.BrandID);
            builder.Entity<City>().HasKey(c => c.ID);
            builder.Entity<Province>().HasKey(p => p.ID);


            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Province> Provinces { get; set; }

    }
}
