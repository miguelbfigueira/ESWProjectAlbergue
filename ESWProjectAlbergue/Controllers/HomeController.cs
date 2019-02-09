using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using ESWProjectAlbergue.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESWProjectAlbergue.Controllers
{
    public class HomeController : Controller
    {
        private ESWProjectAlbergueContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ApplicationUser> _logger;

        public HomeController(ESWProjectAlbergueContext context,
              UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<ApplicationUser> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult About()
        {
            ViewData["Message"] = "Sobre nos";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Página de Contactos";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // POST: AllUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                Console.WriteLine("é null");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var users = _userManager.Users.ToList();
                ApplicationUser userToDelete = (from u in users where u.Id == id select u).First();
                await _userManager.DeleteAsync(userToDelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AllUsers/Edit/5
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                Console.WriteLine("é null");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var users = _userManager.Users.ToList();
                ApplicationUser userToPromote = (from u in users where u.Id == id select u).First();
                userToPromote.Role = "funcionarios";
                await _userManager.AddToRoleAsync(userToPromote, "funcionarios");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Dashboard()
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
