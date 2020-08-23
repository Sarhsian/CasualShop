using System;
using CasualShop.Areas.Identity.Data;
using CasualShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CasualShop.Areas.Identity.IdentityHostingStartup))]
namespace CasualShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CasualShopUserDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CasualShopDbContextConnection")));
                //Confirm account after sign up
                services.AddDefaultIdentity<CasualShopUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<CasualShopUserDbContext>();
            });
        }
    }
}