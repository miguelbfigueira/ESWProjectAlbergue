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
    public class AnimalBreedsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public AnimalBreedsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: AnimalBreeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalBreed.ToListAsync());
        }

        // GET: AnimalBreeds/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalBreeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalBreed = await _context.AnimalBreed.FindAsync(id);
            _context.AnimalBreed.Remove(animalBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalBreedExists(int id)
        {
            return _context.AnimalBreed.Any(e => e.Id == id);
        }
    }
}
