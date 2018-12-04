using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESWProjectAlbergue.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
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

            [Required(ErrorMessage = "Campo obrigatório. Insira o seu nome completo.")]
            [DataType(DataType.Text)]
            [Display(Name = "Nome Completo")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Campo obrigatório. Insira a sua data de nascimento.")]
            [Display(Name = "Data De Nascimento")]
            [DataType(DataType.DateTime)]
            public DateTime BirthDate { get; set; }

            [Required(ErrorMessage = "Campo obrigatório. Insira a sua morada.")]
            [DataType(DataType.Text)]
            [Display(Name = "Morada")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Campo obrigatório. Insira o seu nome completo.")]
            [DataType(DataType.PostalCode)]
            [Display(Name = "Código Postal")]
            public string PostalCode { get; set; }


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
                Name = user.Name,
                Address = user.Address,
                BirthDate = user.BirthDate,
                PostalCode = user.Postalcode,
                Email = email,
                PhoneNumber = phoneNumber
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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


            Input = new InputModel
            {
                Name = Input.Name,
                Address = Input.Address,
                BirthDate = Input.BirthDate,
               
               
            };
            
            user.Name = Input.Name;
            user.Address = Input.Address;
            user.BirthDate = Input.BirthDate;
           // user.Postalcode = Input.PostalCode;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
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
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $" <p> Olá caro(a) utilizador(a), obrigado por ter criado uma conta na quinta do mião. </p> <p> Para finalizar o seu registo é necessário confirmar o seu endereço de e-mail. Para confirmar <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clique aqui</a>. </p> <p>Não responda a este e-mail, pois é um serviço automatizado.</p> <br> <br> <p>A equipa Quinta Do Mião</p> <p> <a href='https://eswprojectalberguedevelopment.azurewebsites.net'>eswprojectalberguedevelopment.azurewebsites.net</a> </p> ");

            StatusMessage = "E-mail de confirmação enviado, por favor verifique o seu e-mail (poderá demorar alguns minutos)";
            return RedirectToPage();
        }
    }
}
