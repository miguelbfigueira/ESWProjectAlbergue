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
    public class ABreedsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public ABreedsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: ABreeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.ABreed.ToListAsync());
        }

        // GET: ABreeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBreed = await _context.ABreed
                .FirstOrDefaultAsync(m => m.ABreedId == id);
            if (aBreed == null)
            {
                return NotFound();
            }

            return View(aBreed);
        }

        // GET: ABreeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ABreeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ABreedId,Designacao")] ABreed aBreed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aBreed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aBreed);
        }

        // GET: ABreeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBreed = await _context.ABreed.FindAsync(id);
            if (aBreed == null)
            {
                return NotFound();
            }
            return View(aBreed);
        }

        // POST: ABreeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ABreedId,Designacao")] ABreed aBreed)
        {
            if (id != aBreed.ABreedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aBreed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ABreedExists(aBreed.ABreedId))
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
            return View(aBreed);
        }

        // GET: ABreeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBreed = await _context.ABreed
                .FirstOrDefaultAsync(m => m.ABreedId == id);
            if (aBreed == null)
            {
                return NotFound();
            }

            return View(aBreed);
        }

        // POST: ABreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aBreed = await _context.ABreed.FindAsync(id);
            _context.ABreed.Remove(aBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ABreedExists(int id)
        {
            return _context.ABreed.Any(e => e.ABreedId == id);
        }
    }
}
