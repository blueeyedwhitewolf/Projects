using System;
//using lab_vinfinita.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using lab_vinfinita.Data;

[assembly: HostingStartup(typeof(lab_vinfinita.Areas.Identity.IdentityHostingStartup))]
namespace lab_vinfinita.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
           
            builder.ConfigureServices((context, services) =>
            {

                ////Só consegue registar utilizadores  quando o seu email for confirmado
                //services.AddDefaultIdentity<IdentityUser>(config =>
                //{
                //    config.SignIn.RequireConfirmedEmail = true;
                //})
                //.AddEntityFrameworkStores<Data.ProjetoContext>();
            });
        }
    }
}