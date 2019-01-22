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
    public class AnimalsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public AnimalsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }



        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var eSWContext = _context.Animal.Include(c => c.Breed);
            return View(await eSWContext.ToListAsync());
        }

       

        // GET: Animals/Details/5
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
        public IActionResult Create()
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
          
            
            return View(animal);
        }

        // GET: Animals/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnimalType,Gender,BirthDate,BreedId,SizeType,FurType,AgeType,Description,BehaviorType,Adopted")] Animal animal)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            if (id != animal.Id)
            {
                return NotFound();
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }

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
