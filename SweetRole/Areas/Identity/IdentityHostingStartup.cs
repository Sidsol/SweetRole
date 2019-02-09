using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SweetRole.Areas.Identity.Data;
using SweetRole.Models;

[assembly: HostingStartup(typeof(SweetRole.Areas.Identity.IdentityHostingStartup))]
namespace SweetRole.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SweetRoleContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SweetRoleContextConnection")));

                services.AddDefaultIdentity<SweetRoleUser>()
                    .AddEntityFrameworkStores<SweetRoleContext>();
            });
        }
    }
}