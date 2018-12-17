using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ESWProjectAlbergue.Areas.Identity.Pages.Account

{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Insira o seu e-mail.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Insira o seu nome completo.")]
            [Display(Name = "Nome Completo")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Insira o a sua Morada.")]
            [Display(Name = "Morada")]
            public string Address { get; set; }

            /*
            [Required(ErrorMessage = "Insira o seu código postal.")]
            [Display(Name = "Código Postal")]
            [DataType(DataType.PostalCode)]
            [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
            public string PostalCode { get; set; }
            */

            [Required]
            [Display(Name = "Data De Nascimento")]
            public DateTime BirthDate { get; set; } 

            [Required(ErrorMessage = "Password inválida. Necessita de uma maiúscula, um valor númerico e um caracter alternativo.")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A password de confirmação não corresponde à password inserida anteriormente.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Address = Input.Address/*, Postalcode = Input.PostalCode*/, BirthDate = Input.BirthDate, Name = Input.Name};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Quinta do Mião- Confirmar E-mail",
                $" <p> Olá caro(a) utilizador(a), obrigado por ter criado uma conta na quinta do mião. </p> <p> Para finalizar o seu registo é necessário confirmar o seu endereço de e-mail. Para confirmar <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clique aqui</a>. </p> <p>Não responda a este e-mail, pois é um serviço automatizado.</p> <br> <br> <p>A equipa Quinta Do Mião</p> <p> <a href='https://eswprojectalberguedevelopment.azurewebsites.net'>eswprojectalberguedevelopment.azurewebsites.net</a> </p> ");


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                Console.WriteLine(user.Name);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
