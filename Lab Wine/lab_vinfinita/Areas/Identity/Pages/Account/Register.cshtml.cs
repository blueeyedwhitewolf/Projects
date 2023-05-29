﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using lab_vinfinita.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace lab_vinfinita.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ProjetoContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            ProjetoContext context,
            RoleManager<IdentityRole> roleManager,
           IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Tipo de Utilizador")]
            public string TipoUtilizador { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync([Bind("IdAdministrador")] Administrador administrador,[Bind("IdUtilizador,Email,Username,Pass,EstadoConta")] Utilizador utilizador, [Bind("IdGarrafeira,EnderecoCodigo,EnderecoMorada,Pass,EnderecoCodigo")] Garrafeira garrafeira, [Bind("IdCliente")] Cliente cliente, [Bind("IdUtilizador,Email,Username,Pass,EstadoConta")] Utilizador utilizador_admin, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (!await _roleManager.RoleExistsAsync("Administrador"))
            {
                //criar role administrador
                var role = new IdentityRole("Administrador");
                await _roleManager.CreateAsync(role);


                //criar utilizador administrador
                var admin = new IdentityUser { UserName = "winebayshop@gmail.com", Email = "winebayshop@gmail.com" };
                var resultado = await _userManager.CreateAsync(admin, "Winebay123-");

                if (resultado.Succeeded)
                {
                    //guardar dados na nossa tabela utilizador
                    utilizador_admin.Pass = "WineBay123-";
                    utilizador_admin.Username = "WineBay123-";
                    utilizador_admin.Email = "WineBay123-";
                    utilizador_admin.EstadoConta = 1;
                    _context.Utilizador.Add(utilizador_admin);
                    HttpContext.Session.SetString("id_admin", utilizador_admin.Email);
                    await _context.SaveChangesAsync();

                    await _userManager.AddToRoleAsync(admin, "Administrador");

                    //Adicionar dados na nossa tabela administrador
                    administrador.IdAdministrador = utilizador_admin.IdUtilizador;
                    _context.Administrador.Add(administrador);
                    await _context.SaveChangesAsync();
                }


            }

            if (ModelState.IsValid)
            {


                if (!await _roleManager.RoleExistsAsync("Cliente"))
                {
                    var role = new IdentityRole("Cliente");
                    await _roleManager.CreateAsync(role);
                }

                if (!await _roleManager.RoleExistsAsync("Garrafeira"))
                {
                    var role = new IdentityRole("Garrafeira");
                    await _roleManager.CreateAsync(role);
                }

                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                //criar novo utilizador na base de dados com estes dados

                if (result.Succeeded)
                {
                    if (Input.TipoUtilizador == "Cliente")
                    {
                        utilizador.Email = Input.Email;
                        utilizador.Username = Input.Email;
                        utilizador.Pass = Input.Password;
                        utilizador.EstadoConta = 1;
                        _context.Utilizador.Add(utilizador);
                        //HttpContext.Session.SetString("Current_user", utilizador.Email);
                        await _context.SaveChangesAsync();
                        await _userManager.AddToRoleAsync(user, "Cliente");
                        cliente.IdCliente = utilizador.IdUtilizador;
                        _context.Cliente.Add(cliente);
                        //HttpContext.Session.SetInt32("Current_cliente", cliente.IdCliente);
                        await _context.SaveChangesAsync();

                        _logger.LogInformation("User created a new account with password.");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Garrafeira");
                        _logger.LogInformation("Para completar e validar o seu registo vá à sua página pessoal inserir os dados necessários.");
                    }

                    
                    //var code= await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id},
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", $"Confirme o seu email <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>");

                    TempData["pendente"] = "Necessita de confirmar a sua conta. Aceda ao seu e-mail para tal.";

                    //comentar para nao fazer logo o login
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
