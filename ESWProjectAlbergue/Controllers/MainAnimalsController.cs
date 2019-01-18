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
    public class MainAnimalsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public MainAnimalsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: MainAnimals
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.MainAnimal.Include(m => m.AnimalAgeType).Include(m => m.AnimalBehaviorType).Include(m => m.AnimalBreed).Include(m => m.AnimalFurType).Include(m => m.AnimalSize).Include(m => m.AnimalType).Include(m => m.GenderType);
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: MainAnimals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainAnimal = await _context.MainAnimal
                .Include(m => m.AnimalAgeType)
                .Include(m => m.AnimalBehaviorType)
                .Include(m => m.AnimalBreed)
                .Include(m => m.AnimalFurType)
                .Include(m => m.AnimalSize)
                .Include(m => m.AnimalType)
                .Include(m => m.GenderType)
                .FirstOrDefaultAsync(m => m.MainAnimalId == id);
            if (mainAnimal == null)
            {
                return NotFound();
            }

            return View(mainAnimal);
        }

        // GET: MainAnimals/Create
        public IActionResult Create()
        {
            ViewData["AnimalAgeTypeId"] = new SelectList(_context.Set<AAgeType>(), "AAgeTypeId", "Designacao");
            ViewData["AnimalBehaviorTypeId"] = new SelectList(_context.Set<ABehaviorType>(), "ABehaviorTypeId", "Designacao");
            ViewData["AnimalBreedId"] = new SelectList(_context.Set<ABreed>(), "ABreedId", "Designacao");
            ViewData["AnimalFurTypeId"] = new SelectList(_context.Set<AFurType>(), "AFurTypeId", "Designacao");
            ViewData["AnimalSizeId"] = new SelectList(_context.Set<ASize>(), "ASizeId", "Designacao");
            ViewData["AnimalTypeId"] = new SelectList(_context.Set<AType>(), "ATypeId", "Designacao");
            ViewData["GenderTypeId"] = new SelectList(_context.Set<AGender>(), "AGenderId", "Designacao");
            return View();
        }

        // POST: MainAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainAnimalId,Name,AnimalTypeId,GenderTypeId,BirthDate,AnimalAgeTypeId,AnimalBreedId,AnimalSizeId,AnimalFurTypeId,AnimalBehaviorTypeId,Description,Adopted,ApplicationUserId")] MainAnimal mainAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalAgeTypeId"] = new SelectList(_context.Set<AAgeType>(), "AAgeTypeId", "Designacao", mainAnimal.AnimalAgeTypeId);
            ViewData["AnimalBehaviorTypeId"] = new SelectList(_context.Set<ABehaviorType>(), "ABehaviorTypeId", "Designacao", mainAnimal.AnimalBehaviorTypeId);
            ViewData["AnimalBreedId"] = new SelectList(_context.Set<ABreed>(), "ABreedId", "Designacao", mainAnimal.AnimalBreedId);
            ViewData["AnimalFurTypeId"] = new SelectList(_context.Set<AFurType>(), "AFurTypeId", "Designacao", mainAnimal.AnimalFurTypeId);
            ViewData["AnimalSizeId"] = new SelectList(_context.Set<ASize>(), "ASizeId", "Designacao", mainAnimal.AnimalSizeId);
            ViewData["AnimalTypeId"] = new SelectList(_context.Set<AType>(), "ATypeId", "Designacao", mainAnimal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.Set<AGender>(), "AGenderId", "Designacao", mainAnimal.GenderTypeId);
            return View(mainAnimal);
        }

        // GET: MainAnimals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainAnimal = await _context.MainAnimal.FindAsync(id);
            if (mainAnimal == null)
            {
                return NotFound();
            }
            ViewData["AnimalAgeTypeId"] = new SelectList(_context.Set<AAgeType>(), "AAgeTypeId", "Designacao", mainAnimal.AnimalAgeTypeId);
            ViewData["AnimalBehaviorTypeId"] = new SelectList(_context.Set<ABehaviorType>(), "ABehaviorTypeId", "Designacao", mainAnimal.AnimalBehaviorTypeId);
            ViewData["AnimalBreedId"] = new SelectList(_context.Set<ABreed>(), "ABreedId", "Designacao", mainAnimal.AnimalBreedId);
            ViewData["AnimalFurTypeId"] = new SelectList(_context.Set<AFurType>(), "AFurTypeId", "Designacao", mainAnimal.AnimalFurTypeId);
            ViewData["AnimalSizeId"] = new SelectList(_context.Set<ASize>(), "ASizeId", "Designacao", mainAnimal.AnimalSizeId);
            ViewData["AnimalTypeId"] = new SelectList(_context.Set<AType>(), "ATypeId", "Designacao", mainAnimal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.Set<AGender>(), "AGenderId", "Designacao", mainAnimal.GenderTypeId);
            return View(mainAnimal);
        }

        // POST: MainAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainAnimalId,Name,AnimalTypeId,GenderTypeId,BirthDate,AnimalAgeTypeId,AnimalBreedId,AnimalSizeId,AnimalFurTypeId,AnimalBehaviorTypeId,Description,Adopted,ApplicationUserId")] MainAnimal mainAnimal)
        {
            if (id != mainAnimal.MainAnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainAnimalExists(mainAnimal.MainAnimalId))
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
            ViewData["AnimalAgeTypeId"] = new SelectList(_context.Set<AAgeType>(), "AAgeTypeId", "Designacao", mainAnimal.AnimalAgeTypeId);
            ViewData["AnimalBehaviorTypeId"] = new SelectList(_context.Set<ABehaviorType>(), "ABehaviorTypeId", "Designacao", mainAnimal.AnimalBehaviorTypeId);
            ViewData["AnimalBreedId"] = new SelectList(_context.Set<ABreed>(), "ABreedId", "Designacao", mainAnimal.AnimalBreedId);
            ViewData["AnimalFurTypeId"] = new SelectList(_context.Set<AFurType>(), "AFurTypeId", "Designacao", mainAnimal.AnimalFurTypeId);
            ViewData["AnimalSizeId"] = new SelectList(_context.Set<ASize>(), "ASizeId", "Designacao", mainAnimal.AnimalSizeId);
            ViewData["AnimalTypeId"] = new SelectList(_context.Set<AType>(), "ATypeId", "Designacao", mainAnimal.AnimalTypeId);
            ViewData["GenderTypeId"] = new SelectList(_context.Set<AGender>(), "AGenderId", "Designacao", mainAnimal.GenderTypeId);
            return View(mainAnimal);
        }

        // GET: MainAnimals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainAnimal = await _context.MainAnimal
                .Include(m => m.AnimalAgeType)
                .Include(m => m.AnimalBehaviorType)
                .Include(m => m.AnimalBreed)
                .Include(m => m.AnimalFurType)
                .Include(m => m.AnimalSize)
                .Include(m => m.AnimalType)
                .Include(m => m.GenderType)
                .FirstOrDefaultAsync(m => m.MainAnimalId == id);
            if (mainAnimal == null)
            {
                return NotFound();
            }

            return View(mainAnimal);
        }

        // POST: MainAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainAnimal = await _context.MainAnimal.FindAsync(id);
            _context.MainAnimal.Remove(mainAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainAnimalExists(int id)
        {
            return _context.MainAnimal.Any(e => e.MainAnimalId == id);
        }
    }
}
