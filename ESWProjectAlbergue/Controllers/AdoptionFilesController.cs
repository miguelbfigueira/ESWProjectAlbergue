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
    public class AdoptionFilesController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public AdoptionFilesController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: AdoptionFiles
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.AdoptionFile.Include(a => a.Animal).Include(u => u.ApplicationUser);
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: AdoptionFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionFile = await _context.AdoptionFile
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionFile == null)
            {
                return NotFound();
            }

            return View(adoptionFile);
        }

        // GET: AdoptionFiles/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
            ViewData["ApplicationUserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        // POST: AdoptionFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimalId,ApplicationUserId")] AdoptionFile adoptionFile)
        {
            if (ModelState.IsValid)
            {
                adoptionFile.Animal = _context.Animal.Find(adoptionFile.AnimalId);
                adoptionFile.ApplicationUser = _context.User.Find(adoptionFile.ApplicationUserId);
                adoptionFile.Date = DateTime.Now;
                _context.Add(adoptionFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", adoptionFile.AnimalId);
           
            ViewData["ApplicationUserId"] = new SelectList(_context.User, "Id", "Name", adoptionFile.ApplicationUserId);
            return View(adoptionFile);
        }

        // GET: AdoptionFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionFile = await _context.AdoptionFile.FindAsync(id);
            if (adoptionFile == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionFile.AnimalId);
            return View(adoptionFile);
        }

        // POST: AdoptionFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimalId,ApplicationUserId")] AdoptionFile adoptionFile)
        {
            if (id != adoptionFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionFileExists(adoptionFile.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionFile.AnimalId);
            return View(adoptionFile);
        }

        // GET: AdoptionFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionFile = await _context.AdoptionFile
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionFile == null)
            {
                return NotFound();
            }

            return View(adoptionFile);
        }

        // POST: AdoptionFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionFile = await _context.AdoptionFile.FindAsync(id);
            _context.AdoptionFile.Remove(adoptionFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionFileExists(int id)
        {
            return _context.AdoptionFile.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> FiltrarRaca(int? id)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            var breeds = await _context.AdoptionFile.Include(a => a.Animal).Include(u => u.ApplicationUser).ToListAsync();
            if (id != null)
            {
                var animais = await _context.Animal.ToListAsync();
                animais = (from a in animais where a.BreedId == id select a).ToList();
                breeds = (from a in breeds from u in animais where a.AnimalId == u.Id select a).ToList();

            }

            if (breeds == null)
            {
                return NotFound();
            }
            return View(breeds);

        }

        [HttpPost]
        public async Task<IActionResult> FiltrarDate(DateTime? date)
        {
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            var breeds = await _context.AdoptionFile.Include(a => a.Animal).Include(u => u.ApplicationUser).ToListAsync();
            if (date != null) { 
            
                breeds = (from a in breeds where a.Date.Date == date select a).ToList();

            }

            if (breeds == null)
            {
                return NotFound();
            }
            return View(breeds);


        }
    }
}
