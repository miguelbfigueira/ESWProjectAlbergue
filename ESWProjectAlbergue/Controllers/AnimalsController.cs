// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 01-21-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="AnimalsController.cs" company="ESWProjectAlbergue">
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
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ESWProjectAlbergue.Controllers
{
    /// <summary>
    /// Class AnimalsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AnimalsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AnimalsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }



        // GET: Animals
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var eSWContext = _context.Animal.Include(c => c.Breed);
            return View(await eSWContext.ToListAsync());
        }



        // GET: Animals/Details/5
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

            var animal = await _context.Animal
                .Include(c => c.Breed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name", animal.BreedId);
            return View(animal);
        }

        // GET: Animals/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified animal.
        /// </summary>
        /// <param name="animal">The animal.</param>
        /// <param name="Photo">The photo.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AnimalType,Gender,BirthDate,BreedId,SizeType,FurType,AgeType,Description,BehaviorType")] Animal animal,List<IFormFile> Photo)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name", animal.BreedId);
           
            foreach (var item in Photo) {
                if (item.Length > 0) {
                    using(var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        animal.Photo = stream.ToArray();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "<script>alert('Animal resgistado com sucesso');</script>";
            ModelState.Clear();
            return View(animal);
        }

        // GET: Animals/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name", animal.BreedId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="animal">The animal.</param>
        /// <param name="Photo">The photo.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnimalType,Gender,BirthDate,BreedId,SizeType,FurType,AgeType,Description,BehaviorType,Adopted")] Animal animal, List<IFormFile> Photo)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            if (id != animal.Id)
            {
                return NotFound();
            }

            foreach (var item in Photo)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        animal.Photo = stream.ToArray();
                    }
                }
            } 
            if (ModelState.IsValid)
            {
                try
                {
                    ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name", animal.BreedId);
                   
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name", animal.BreedId);
            return View(animal);
        }

        // GET: Animals/Delete/5
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

            var animal = await _context.Animal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Animals the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }

        /// <summary>
        /// Filtrar os animais pelo seu número de identificação
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Um view com o animal com o número de identificação selecionado</returns>
        [HttpPost]
        public async Task<IActionResult> FiltrarNumero(int? id)
        {
            var animais = await _context.Animal.ToListAsync();
            if (id != null)
            {
                animais = (from a in animais where a.Id == id select a).ToList();

            }

            if (animais == null)
            {
                return NotFound();
            }
            return View(animais);

        }

        /// <summary>
        /// Filtrars the nome.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        public async Task<IActionResult> FiltrarNome(string name)
        {
            var animais = await _context.Animal.ToListAsync();
            if (!String.IsNullOrEmpty(name))
            {
                animais = (from a in animais where a.Name.Contains(name) select a).ToList();
            }
            return View(animais);

        }
    }
}
