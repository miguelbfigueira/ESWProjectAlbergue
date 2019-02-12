// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 02-08-2019
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="PerfectAnimalsController.cs" company="ESWProjectAlbergue">
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
    /// Class PerfectAnimalsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class PerfectAnimalsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfectAnimalsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PerfectAnimalsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: PerfectAnimals
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.PerfectAnimal.Include(p => p.Breed);
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name");
            return View(nameof(Create));
        }

        // GET: PerfectAnimals/Details/5
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

            var perfectAnimal = await _context.PerfectAnimal
                .Include(p => p.Breed)
                .FirstOrDefaultAsync(m => m.PerfectAnimalId == id);
            if (perfectAnimal == null)
            {
                return NotFound();
            }

            return View(perfectAnimal);
        }

        // GET: PerfectAnimals/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name");
            return View();
        }

        // POST: PerfectAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: PerfectAnimals/Edit/5
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

            var perfectAnimal = await _context.PerfectAnimal.FindAsync(id);
            if (perfectAnimal == null)
            {
                return NotFound();
            }
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name", perfectAnimal.BreedId);
            return View(perfectAnimal);
        }

        // POST: PerfectAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="perfectAnimal">The perfect animal.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerfectAnimalId,Size,Gender,BreedId,Age,Type")] PerfectAnimal perfectAnimal)
        {
            if (id != perfectAnimal.PerfectAnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfectAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfectAnimalExists(perfectAnimal.PerfectAnimalId))
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
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name", perfectAnimal.BreedId);
            return View(perfectAnimal);
        }

        // GET: PerfectAnimals/Delete/5
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

            var perfectAnimal = await _context.PerfectAnimal
                .Include(p => p.Breed)
                .FirstOrDefaultAsync(m => m.PerfectAnimalId == id);
            if (perfectAnimal == null)
            {
                return NotFound();
            }

            return View(perfectAnimal);
        }

        // POST: PerfectAnimals/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfectAnimal = await _context.PerfectAnimal.FindAsync(id);
            _context.PerfectAnimal.Remove(perfectAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Perfects the animal exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool PerfectAnimalExists(int id)
        {
            return _context.PerfectAnimal.Any(e => e.PerfectAnimalId == id);
        }


        /// <summary>
        /// Filtrar os animais de acordo com as caracteristicas procuradas pelo utilizador
        /// </summary>
        /// <param name="perfectAnimal">The perfect animal.</param>
        /// <returns>Um view com o animal  que for 100% o que o ulizador procura ou varios ordenados pelas percentagens de compatibilidade</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnimalIdeal([Bind("PerfectAnimalId,Size,Gender,BreedId,Age,Type")] PerfectAnimal perfectAnimal)
        {
            var percentagem = 0;
            List<PerfectAnimal> animal = new List<PerfectAnimal>();
            var animaisideais = from a in _context.Animal select a;
            var animalIdeal = from a in _context.Animal where a.AnimalType == perfectAnimal.Type && a.Gender == perfectAnimal.Gender && a.AgeType == perfectAnimal.Age && a.BreedId == perfectAnimal.BreedId &&  a.SizeType == perfectAnimal.Size select a;
            if(animalIdeal.Count() >= 1)
            {
                foreach (var item in animalIdeal)
                { 
                    var pA = new PerfectAnimal { Animal = item };
                    pA.Percentagem = 100;
                    animal.Add(pA);
                }
                return View(animal);
            }
            var animaistipo = from a in _context.Animal where a.AnimalType == perfectAnimal.Type && a.Adopted == false select a;

            if (animaistipo.Count() == 0)
            {
                return NotFound();
            }
            if (animaistipo.Count() >= 1)
            {
                foreach (var item in animaistipo)
                {        
                    animal.Add(HowPerfect(new PerfectAnimal(), item));
                }
                
            }
            
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name", perfectAnimal.BreedId);
            animal.Sort((x, y) => x.Percentagem.CompareTo(y.Percentagem));
            animal.Reverse();
            return View(animal);
        }

        /// <summary>
        /// Analisa os animais consoante as caracteristicas do utilizadpr
        /// </summary>
        /// <param name="perfectAnimal">The perfect animal.</param>
        /// <param name="animal">The animal.</param>
        /// <returns>O animal com a sua percentagem de compatibilidade</returns>
        public PerfectAnimal HowPerfect(PerfectAnimal perfectAnimal, Animal animal)
        {
            var count = 0;

            if(perfectAnimal.Type == animal.AnimalType)
            {
                count += 20;
            }
            if (perfectAnimal.Gender == animal.Gender)
            {
                count += 20;
            }
            if (perfectAnimal.Age == animal.AgeType)
            {
                count += 20;
            }
            if (perfectAnimal.BreedId == animal.BreedId)
            {
                count += 20;
            }
            if (perfectAnimal.Size == animal.SizeType)
            {
                count += 20;
            }

            perfectAnimal.AnimalId = animal.Id;
            perfectAnimal.Animal = animal;
            perfectAnimal.Percentagem = count;
            return perfectAnimal;

        }

    }
}
