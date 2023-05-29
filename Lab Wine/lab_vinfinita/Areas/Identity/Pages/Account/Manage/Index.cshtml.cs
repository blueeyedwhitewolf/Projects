using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using lab_vinfinita.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab_vinfinita.Areas.Identity.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace lab_vinfinita.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ProjetoContext _context;
        private readonly IEmailSender _emailSender;
        IHostingEnvironment _hostingEnvironment;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
              ProjetoContext context,
          //    ApplicationDbContext applicationDbContext,
             IEmailSender emailSender,
              IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public string Codigo { get; set; }

            public string Morada { get; set; }

            public string Localidade { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);


            return Page();
        }

        public async Task<IActionResult> OnPostAsync([Bind("IdUtilizador,Email,Username,Pass,EstadoConta")] Utilizador utilizador, [Bind("IdGarrafeira,EnderecoCodigo,EnderecoMorada,Pass,EnderecoCodigo")] Garrafeira garrafeira)
        {
            if (!ModelState.IsValid)
            {
               

                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if(User.IsInRole("Garrafeira"))
            {
                //so agora adicionamos a garrafeira com todos os seus dados

                utilizador.Email = user.Email;
                utilizador.Username = user.Email;
                utilizador.Pass = user.PasswordHash;
                utilizador.EstadoConta = 1;
                _context.Utilizador.Add(utilizador);
                await _context.SaveChangesAsync();
                //HttpContext.Session.SetString("Current_user",utilizador.Email);

                garrafeira.IdGarrafeira = utilizador.IdUtilizador;
                garrafeira.EnderecoCodigo = Input.Codigo;
                garrafeira.EnderecoLocalidade = Input.Localidade;
                garrafeira.EnderecoMorada = Input.Morada;
                _context.Garrafeira.Add(garrafeira);
                await _context.SaveChangesAsync();
                //HttpContext.Session.SetInt32("Current_garraf", garrafeira.IdGarrafeira);
            }

            //
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            //

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "O seu perfil foi atualizado";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code=code},
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
              email,
              "Confirm your email",
              $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");



            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
