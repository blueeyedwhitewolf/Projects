using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab_vinfinita.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace lab_vinfinita.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ProjetoContext _context;
     //   private readonly ApplicationDbContext _applicationDbContext;
        IHostingEnvironment _hostingEnvironment;

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ProjetoContext context,
            IHostingEnvironment hostingEnvironment)
          //  ApplicationDbContext applicationDbContext)
        {
          //  _applicationDbContext = applicationDbContext;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

 
        [Authorize(Roles ="Cliente")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contacte a garrafeira.";

            return View();
        }

        //[Authorize(Roles ="Administrador")]
        public async Task<IActionResult> GerirUtilizadores()
        {
            var util = _context.Utilizador; //.Include(r => r.Possuir.IdProdutorNavigation).Include(r => r.Possuir.IdRegiaoNavigation).Include(r => r.Possuir.IdTipoNavigation);
            return View(await util.ToListAsync());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
