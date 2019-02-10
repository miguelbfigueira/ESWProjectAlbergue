// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 01-18-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="VisitsController.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ESWProjectAlbergue.Controllers
{
    /// <summary>
    /// Class VisitsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class VisitsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender _emailSender;


        /// <summary>
        /// Initializes a new instance of the <see cref="VisitsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="emailSender">The email sender.</param>
        public VisitsController(ESWProjectAlbergueContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Visits
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.Visit.Include(v => v.UserToVisit);
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: Visits/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit
                .Include(v => v.UserToVisit)
                .FirstOrDefaultAsync(m => m.VisitId == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: Visits/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["UserToVisitId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        /// <summary>
        /// Cria uma visita e envia um email com as informações
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <returns>A visita</returns>
        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitId,Description,UserToVisitId,Date")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visit);
                await _context.SaveChangesAsync();
                var user = _context.User.Find(visit.UserToVisitId);
                await _emailSender.SendEmailAsync(user.Email, "Marcação de uma visita",
                   $"<h1>Marcação de Visita </h1> " +
                   $"<h4>Tem uma visita marcada para {visit.Date}.</h4> " +
                   $"<p>Descrição: {visit.Description} </p>" + 
                   $"<p>Caso não possa na data marcada contacte o canil.</p>");

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserToVisitId"] = new SelectList(_context.User, "Id", "Name", visit.UserToVisitId);
            return View(visit);
        }

        // GET: Visits/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            ViewData["UserToVisitId"] = new SelectList(_context.User, "Id", "Name", visit.UserToVisitId);
            return View(visit);
        }

        /// <summary>
        /// Editado uma visita e envia um email com as informações
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="visit">The visit.</param>
        /// <returns>A visita</returns>
        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitId,Description,UserToVisitId,Date")] Visit visit)
        {
            if (id != visit.VisitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visit);
                    await _context.SaveChangesAsync();
                    var user = _context.User.Find(visit.UserToVisitId);
                    await _emailSender.SendEmailAsync(user.Email, "ALTERAÇÃO - Marcação de uma visita",
                 $"<h1> Alteração  da Visita </h1> " +
                 $"<h4> Tem uma visita marcada para {visit.Date}.</h4> " +
                 $"<p> Descrição: {visit.Description} </p>" +
                 $"<p>Caso não possa na data marcada contacte o canil.</p>");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.VisitId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserToVisitId"] = new SelectList(_context.User, "Id", "Name", visit.UserToVisitId);
            return View(visit);
        }

        // GET: Visits/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit
                .Include(v => v.UserToVisit)
                .FirstOrDefaultAsync(m => m.VisitId == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // POST: Visits/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visit = await _context.Visit.FindAsync(id);
            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Visits the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool VisitExists(int id)
        {
            return _context.Visit.Any(e => e.VisitId == id);
        }
    }
}
