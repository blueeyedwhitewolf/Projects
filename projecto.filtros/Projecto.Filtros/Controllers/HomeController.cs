using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projecto.Filtros.Filters;
using Projecto.Filtros.Models;

namespace Projecto.Filtros.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
       
        [MyFilterXpto("Andre Sousa")]
        //[TimeRestrictionFilter]
        public IActionResult Index()
        {
            return View();
        }

        [MyFilterXpto("andresousa@utad.pt")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public IActionResult About()
        {
            ViewData["Message"] = DateTime.Now.ToString();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
