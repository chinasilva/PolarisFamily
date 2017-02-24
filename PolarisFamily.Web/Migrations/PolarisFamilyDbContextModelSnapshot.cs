using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PolarisFamily.Data;

namespace PolarisFamily.Web.Migrations
{
    [DbContext(typeof(PolarisFamilyDbContext))]
    partial class PolarisFamilyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PolarisFamily.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("PolarisFamily.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandName");

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("PolarisFamily.Models.CartItem", b =>
                {
                    b.Property<Guid>("CartID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.Property<string>("SessionID");

                    b.Property<float>("SubTotal");

                    b.Property<string>("ThumbImagePath");

                    b.Property<float>("UnitPrice");

                    b.Property<string>("UserID");

                    b.HasKey("CartID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("PolarisFamily.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PolarisFamily.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityIndex");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceID");

                    b.HasKey("ID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PolarisFamily.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("Description");

                    b.Property<string>("ImageName");

                    b.Property<int?>("NewsID");

                    b.Property<int?>("ProductID");

                    b.Property<DateTime?>("RecordTime");

                    b.Property<string>("RecordUser");

                    b.Property<string>("RelativeUrl");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.HasKey("ImageID");

                    b.HasIndex("NewsID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PolarisFamily.Models.ImageRevolution", b =>
                {
                    b.Property<int>("ImageRevolutionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ImageID");

                    b.Property<int?>("NewsID");

                    b.Property<int?>("ProductID");

                    b.HasKey("ImageRevolutionID");

                    b.ToTable("ImageRevolutions");
                });

            modelBuilder.Entity("PolarisFamily.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("NewFlag");

                    b.Property<string>("NewsDescription");

                    b.Property<string>("NewsName");

                    b.Property<DateTime?>("RecordTime");

                    b.Property<string>("RecordUser");

                    b.Property<string>("RelativeUrl");

                    b.Property<int>("ThemeID");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.HasKey("NewsID");

                    b.HasIndex("ThemeID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("PolarisFamily.Models.NewsRevolution", b =>
                {
                    b.Property<int>("newsRevolationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("newsID");

                    b.Property<int>("themeID");

                    b.HasKey("newsRevolationID");

                    b.ToTable("NewsRevolution");
                });

            modelBuilder.Entity("PolarisFamily.Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime?>("OrderDate");

                    b.Property<int>("OrderStatus");

                    b.Property<float?>("TotalPrice");

                    b.Property<string>("UserID");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PolarisFamily.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("OrderID");

                    b.Property<DateTime?>("PlaceDate");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.Property<float?>("SubTotal");

                    b.Property<string>("ThumbImagePath");

                    b.Property<float?>("UnitPrice");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PolarisFamily.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandID");

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Currency");

                    b.Property<string>("Description");

                    b.Property<float?>("Height");

                    b.Property<DateTime?>("LastUpdatedTime");

                    b.Property<float?>("Length");

                    b.Property<string>("ProductName");

                    b.Property<string>("ThumbnailImage");

                    b.Property<string>("UnitOfLength");

                    b.Property<string>("UnitOfWeight");

                    b.Property<float?>("UnitPrice");

                    b.Property<float?>("UntiPrice");

                    b.Property<float?>("Weight");

                    b.Property<float?>("Width");

                    b.HasKey("ProductID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PolarisFamily.Models.Province", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("PolarisFamily.Models.ShipAddress", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("City");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Province");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("UserID");

                    b.Property<string>("ZipCode");

                    b.HasKey("AddressID");

                    b.ToTable("ShipAddress");
                });

            modelBuilder.Entity("PolarisFamily.Models.Theme", b =>
                {
                    b.Property<int>("ThemeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime?>("RecordTime");

                    b.Property<string>("RecordUser");

                    b.Property<string>("ThemeName");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.HasKey("ThemeID");

                    b.ToTable("Theme");
                });

            modelBuilder.Entity("PolarisFamily.Models.Video", b =>
                {
                    b.Property<int>("VideoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("NewsID");

                    b.Property<int?>("ProductID");

                    b.Property<DateTime?>("RecordTime");

                    b.Property<string>("RecordUser");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("UpdateUser");

                    b.Property<string>("VideoName");

                    b.Property<string>("VideoRelativeUrl");

                    b.HasKey("VideoID");

                    b.HasIndex("NewsID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("PolarisFamily.Models.VideoRevolution", b =>
                {
                    b.Property<int>("VideoRevolutionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("NewsID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("VideoID");

                    b.HasKey("VideoRevolutionID");

                    b.ToTable("VideoRevolutions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PolarisFamily.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PolarisFamily.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("PolarisFamily.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolarisFamily.Models.City", b =>
                {
                    b.HasOne("PolarisFamily.Models.Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolarisFamily.Models.Image", b =>
                {
                    b.HasOne("PolarisFamily.Models.News")
                        .WithOne("Images")
                        .HasForeignKey("PolarisFamily.Models.Image", "NewsID");

                    b.HasOne("PolarisFamily.Models.Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("PolarisFamily.Models.News", b =>
                {
                    b.HasOne("PolarisFamily.Models.Theme", "Themes")
                        .WithMany()
                        .HasForeignKey("ThemeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolarisFamily.Models.OrderDetail", b =>
                {
                    b.HasOne("PolarisFamily.Models.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolarisFamily.Models.Product", b =>
                {
                    b.HasOne("PolarisFamily.Models.Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PolarisFamily.Models.Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("PolarisFamily.Models.Video", b =>
                {
                    b.HasOne("PolarisFamily.Models.News")
                        .WithOne("Videos")
                        .HasForeignKey("PolarisFamily.Models.Video", "NewsID");

                    b.HasOne("PolarisFamily.Models.Product")
                        .WithMany("Videos")
                        .HasForeignKey("ProductID");
                });
        }
    }
}
