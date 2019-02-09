// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 01-22-2019
//
// Last Modified By : migue
// Last Modified On : 01-22-2019
// ***********************************************************************
// <copyright file="AnimalBreedsController.cs" company="ESWProjectAlbergue">
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
    /// Class AnimalBreedsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AnimalBreedsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalBreedsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AnimalBreedsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: AnimalBreeds
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalBreed.ToListAsync());
        }

        // GET: AnimalBreeds/Details/5
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

            var animalBreed = await _context.AnimalBreed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalBreed == null)
            {
                return NotFound();
            }

            return View(animalBreed);
        }

        // GET: AnimalBreeds/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalBreeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified animal breed.
        /// </summary>
        /// <param name="animalBreed">The animal breed.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Behavior")] AnimalBreed animalBreed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalBreed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalBreed);
        }

        // GET: AnimalBreeds/Edit/5
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

            var animalBreed = await _context.AnimalBreed.FindAsync(id);
            if (animalBreed == null)
            {
                return NotFound();
            }
            return View(animalBreed);
        }

        // POST: AnimalBreeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="animalBreed">The animal breed.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Behavior")] AnimalBreed animalBreed)
        {
            if (id != animalBreed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalBreed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalBreedExists(animalBreed.Id))
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
            return View(animalBreed);
        }

        // GET: AnimalBreeds/Delete/5
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

            var animalBreed = await _context.AnimalBreed
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalBreed == null)
            {
                return NotFound();
            }

            return View(animalBreed);
        }

        // POST: AnimalBreeds/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalBreed = await _context.AnimalBreed.FindAsync(id);
            _context.AnimalBreed.Remove(animalBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Animals the breed exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool AnimalBreedExists(int id)
        {
            return _context.AnimalBreed.Any(e => e.Id == id);
        }
    }
}
