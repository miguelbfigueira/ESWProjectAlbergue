// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 01-22-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="PosConditionsFormsController.cs" company="ESWProjectAlbergue">
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

namespace ESWProjectAlbergue.Controllers
{
    /// <summary>
    /// Class PosConditionsFormsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class PosConditionsFormsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PosConditionsFormsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PosConditionsFormsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }



        // GET: PosConditionsForms
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.PosConditionsForm.Include(p => p.AdoptionFile);
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: PosConditionsForms/Details/5
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

            var posConditionsForm = await _context.PosConditionsForm
                .Include(p => p.AdoptionFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }

            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id");
            return View();
        }

        // POST: PosConditionsForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified position conditions form.
        /// </summary>
        /// <param name="posConditionsForm">The position conditions form.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdoptionFileId,Answer1,Answer2,Answer3,result")] PosConditionsForm posConditionsForm)
        {
            if (ModelState.IsValid)
            {
                if(posConditionsForm.Answer1 == true && posConditionsForm.Answer2 == true && posConditionsForm.Answer3 == true)
                {
                    posConditionsForm.result = true;
                }
                else
                {
                    posConditionsForm.result = false;
                }
                _context.Add(posConditionsForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Edit/5
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

            var posConditionsForm = await _context.PosConditionsForm.FindAsync(id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // POST: PosConditionsForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="posConditionsForm">The position conditions form.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdoptionFileId,Answer1,Answer2,Answer3,result")] PosConditionsForm posConditionsForm)
        {
            if (id != posConditionsForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (posConditionsForm.Answer1 == true && posConditionsForm.Answer2 == true && posConditionsForm.Answer3 == true)
                    {
                        posConditionsForm.result = true;
                    }
                    else
                    {
                        posConditionsForm.result = false;
                    }
                    _context.Update(posConditionsForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosConditionsFormExists(posConditionsForm.Id))
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
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Delete/5
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

            var posConditionsForm = await _context.PosConditionsForm
                .Include(p => p.AdoptionFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }

            return View(posConditionsForm);
        }

        // POST: PosConditionsForms/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posConditionsForm = await _context.PosConditionsForm.FindAsync(id);
            _context.PosConditionsForm.Remove(posConditionsForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Positions the conditions form exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool PosConditionsFormExists(int id)
        {
            return _context.PosConditionsForm.Any(e => e.Id == id);
        }
    }
}
