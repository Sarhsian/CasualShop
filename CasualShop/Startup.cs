using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasualShop.DAL;
using CasualShop.DAL.Repository;
using CasualShop.DAL.Repository.Implementations;
using CasualShop.DAL.Repository.Interfaces;
using CasualShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;

namespace CasualShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("CasualShopDbContextConnection");
            
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("CasualShop.DAL")));

            //dependency injection
            services.AddTransient<IClothesRepository, EFClothesRepository>();
            services.AddTransient<ITagsRepository, EFTagsRepository>();
            services.AddTransient<IBrandsRepository, EFBrandsRepository>();
            services.AddTransient<IBasketsRepository, EFBasketRepository>();

            services.AddScoped<DataManager>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shop/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
