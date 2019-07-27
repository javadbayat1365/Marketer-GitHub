using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Marketer.App.Data;
using Marketer.App.Models;
using Marketer.App.Services;
using Marketer.DataLayer.Repositories;
using Marketer.Services.Product;
using Marketer.DataLayer.Context;

namespace Marketer.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddDbContext<MarketerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyMarketerDbContext")));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductService>();


            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areas", template: "{api}/{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
