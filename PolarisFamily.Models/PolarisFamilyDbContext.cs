using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PolarisFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolarisFamily.Data
{
    public class PolarisFamilyDbContext:IdentityDbContext<IdentityUser>
    {
        public PolarisFamilyDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建Models
            builder.Entity<ApplicationUser>().HasKey(a => a.Id);
            builder.Entity<Brand>().HasKey(b => b.BrandID);
            builder.Entity<CartItem>().HasKey(c => c.CartID);
            builder.Entity<Category>().HasKey(c => c.CategoryID);
            builder.Entity<City>().HasKey(c => c.ID);
            builder.Entity<Image>().HasKey(c => c.ImageID);
            builder.Entity<ImageRevolution>().HasKey(i => i.ImageRevolutionID);
            builder.Entity<News>().HasKey(n => n.NewsID);
            builder.Entity<NewsRevolution>().HasKey(n2 => n2.newsRevolationID);
            builder.Entity<Order>().HasKey(o => o.OrderID);
            builder.Entity<OrderDetail>().HasKey(o => o.OrderDetailID);
            builder.Entity<Product>().HasKey(p=>p.ProductID);
            builder.Entity<Province>().HasKey(p => p.ID);
            builder.Entity<ShipAddress>().HasKey(s => s.AddressID);
            builder.Entity<Theme>().HasKey(t => t.ThemeID);
            builder.Entity<Video>().HasKey(v => v.VideoID);
            builder.Entity<VideoRevolution>().HasKey(v => v.VideoRevolutionID);

            base.OnModelCreating(builder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageRevolution> ImageRevolutions { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsRevolution> NewsRevolution { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<ShipAddress> ShipAddress { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoRevolution> VideoRevolutions{ get; set; }

    }
}
