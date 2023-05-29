using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace lab_vinfinita.Controllers
{
    public class GestorRolesController : Controller
    {
        IServiceProvider _services;

        public GestorRolesController(IServiceProvider service)
        {
            _services = service;
        }

        [Authorize]
        public IActionResult Index()
        {
            //procurar o gestor de Roles do sistema

            IdentityResult identityResult;
            var rolemanager = _services.GetService <RoleManager<IdentityRole>>();

           if(!rolemanager.RoleExistsAsync("Administrador").Result)
            {
                identityResult = rolemanager.CreateAsync(new IdentityRole("Administrador")).Result;
            }

            if (!rolemanager.RoleExistsAsync("Cliente").Result)
            {
                identityResult = rolemanager.CreateAsync(new IdentityRole("Cliente")).Result;
            }

            if (!rolemanager.RoleExistsAsync("Garrafeira").Result)
            {
                identityResult = rolemanager.CreateAsync(new IdentityRole("Garrafeira")).Result;
            }

            var usermanager = _services.GetService<UserManager<IdentityUser>>();

            var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if(!User.IsInRole("Administrador"))
            {
                var usr = usermanager.FindByIdAsync(userid).Result;
                identityResult = usermanager.AddToRoleAsync(usr, "Administrador").Result;
            }

            if (!User.IsInRole("Cliente"))
            {
                var usr = usermanager.FindByIdAsync(userid).Result;
                identityResult = usermanager.AddToRoleAsync(usr, "Cliente").Result;
            }

            if (!User.IsInRole("Garrafeira"))
            {
                var usr = usermanager.FindByIdAsync(userid).Result;
                identityResult = usermanager.AddToRoleAsync(usr, "Garrafeira").Result;
            }

            return View();
        }
    }
}