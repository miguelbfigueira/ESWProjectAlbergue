// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 11-20-2018
//
// Last Modified By : migue
// Last Modified On : 01-18-2019
// ***********************************************************************
// <copyright file="HomeController.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ESWProjectAlbergueContext _context;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;
        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ApplicationUser> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="emailSender">The email sender.</param>
        /// <param name="logger">The logger.</param>
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


        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Sobre nos";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Página de Contactos";

            return View();
        }

        /// <summary>
        /// Privacies this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        // POST: AllUsers/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
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


        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
