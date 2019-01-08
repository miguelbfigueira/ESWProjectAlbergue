using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ESWProjectAlbergue.Areas.Identity.Pages.Account.Manage
{
    public partial class AllUsersModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ApplicationUser> _logger;

        public AllUsersModel(
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

        public List<ApplicationUser> users { get; set; }
        

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
            users =  _userManager.Users.ToList();
            return Page();
        }

        
        public async Task<IActionResult> FiltrarFuncionarios()
        {
            var funcs = _userManager.Users.ToList();
            users = (from u in funcs where u.Role == "funcionarios" select u).ToList();
            return await OnGetAsync();
        }

        public void Promote(string id)
        {
            foreach(ApplicationUser user in users)
            {
                if(user.Id == id)
                {
                    user.Role = "funcionarios";
                    _userManager.AddToRoleAsync(user, "funcionarios");
                }
            }
            
        }

        

        /* public async Task<IActionResult> OnGetAsync()
         {
             var user = await _userManager.GetUserAsync(User);
             if (user == null)
             {
                 return NotFoun d($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
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
         }*/

       
    }
}
