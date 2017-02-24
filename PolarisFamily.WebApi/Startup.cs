using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PolarisFamily.Data;
using Microsoft.EntityFrameworkCore;
using PolarisFamily.Data.Interfaces;
using PolarisFamily.Data.Repositories;
using PolarisFamily.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PolarisFamily.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            AddDependencies(services);

            services.Configure<WebApiSettings>(settings => settings.HostName = Configuration["HostName"]);
            services.Configure<WebApiSettings>(settings => settings.SecretKey = Configuration["SecretKey"]);


            services.AddDbContext<PolarisFamilyDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
             //解决SQL server2008R2一下 OFFSET/FETCH方法
             opt => opt.UseRowNumberForPaging()));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PolarisFamilyDbContext>()
                .AddDefaultTokenProviders();
            // Add framework services.
            services.AddMvc();

            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(20));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            // Add ASP.NET Core Identity
            app.UseIdentity().UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AccessDeniedPath = new PathString("/api/v1/Account/Login"),
                    LoginPath = new PathString("/api/v1/Account/Login")
                });

            // Add JWT　Protection
            var secretKey = Configuration["SecretKey"];
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match! 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                // Validate the JWT Issuer (iss) claim 
                ValidateIssuer = true,
                ValidIssuer = "PolarisFamily",
                // Validate the JWT Audience (aud) claim 
                ValidateAudience = true,
                ValidAudience = "PolarisFamilyAudience",
                // Validate the token expiry 
                ValidateLifetime = true,
                // If you want to allow a certain amount of clock drift, set that here: 
                ClockSkew = TimeSpan.Zero
            };
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });


            app.UseMvc();
            app.UseStaticFiles();
        }
        public IServiceCollection AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IVideoRepository, VideosRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();

            //services.AddScoped<ICartItemRepository, CartItemRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IShipAddressRepository, ShipAddressRepository>();
            services.AddScoped<PolarisFamilyDbContext>();
            return services;
        }
    }
}
