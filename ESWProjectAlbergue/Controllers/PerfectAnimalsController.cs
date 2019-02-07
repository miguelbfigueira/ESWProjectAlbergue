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
    public class PerfectAnimalsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public PerfectAnimalsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: PerfectAnimals
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.PerfectAnimal.Include(p => p.Breed);
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name");
            return View(nameof(Create));
        }

        // GET: PerfectAnimals/Details/5
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
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name");
            return View();
        }

        // POST: PerfectAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: PerfectAnimals/Edit/5
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfectAnimal = await _context.PerfectAnimal.FindAsync(id);
            _context.PerfectAnimal.Remove(perfectAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfectAnimalExists(int id)
        {
            return _context.PerfectAnimal.Any(e => e.PerfectAnimalId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAnimalIdeal([Bind("PerfectAnimalId,Size,Gender,BreedId,Age,Type")] PerfectAnimal perfectAnimal)
        {
            var percentagem = 0;
            var animaisideais = from a in _context.Animal select a;
            var animalIdeal = from a in _context.Animal where a.AnimalType == perfectAnimal.Type && a.Gender == perfectAnimal.Gender && a.AgeType == perfectAnimal.Age && a.BreedId == perfectAnimal.BreedId &&  a.SizeType == perfectAnimal.Size select a;
            if(animalIdeal.Count() >= 1)
            {
                ViewData["Percentagem"] = 100;
                return View(animalIdeal);
            }
            Console.WriteLine("vou procuarr");
            var animaistipo = from a in _context.Animal where a.AnimalType == perfectAnimal.Type && a.Adopted == false select a;

            if (animaistipo.Count() == 0)
            {
                return NotFound();
            }
            if (animaistipo != null)
            {
                percentagem += 20;
            }
            var animaisgenero = from a in _context.Animal where a.Gender == perfectAnimal.Gender && a.Adopted == false select a;
            if(animaisgenero != null)
            {
                percentagem += 20;
                foreach(var a in animaistipo)
                {
                    if (animaisgenero.Contains(a))
                    {
                        animaisideais = from m in animaistipo from n in animaisgenero where m == n select m;
                       percentagem += 20;
                    }
                }
            }

            ViewData["Percentagem"] = percentagem;
            ViewData["BreedId"] = new SelectList(_context.AnimalBreed, "Id", "Name", perfectAnimal.BreedId);
            return View(animaisideais);
        }

    }
}
