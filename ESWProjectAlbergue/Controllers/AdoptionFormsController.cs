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
    public class AdoptionFormsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public AdoptionFormsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: AdoptionForms
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.AdoptionForm.Include(a => a.Animal);
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: AdoptionForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForm
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionForm == null)
            {
                return NotFound();
            }

            return View(adoptionForm);
        }

        // GET: AdoptionForms/Create
        public async Task<IActionResult> Create(int? id)
        {
            var adoptionForm = new AdoptionForm();
            adoptionForm.Animal = await _context.Animal.FindAsync(id);
            adoptionForm.AnimalId = adoptionForm.Animal.Id;
            ViewData["ApplicationUserId"] = new SelectList(_context.User, "Id", "Id");
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionForm.AnimalId);
            return View(adoptionForm);
        }

        // POST: AdoptionForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,AnimalId,ApplicationUserId,Date,Cc,Job,MoreAnimals,HowMany,AnimalTypes,FinanciallyStable,HouseType,NumberOfBedrooms,NumberOfPeople,AnimalTravel,LeaveHouse,Conscious,TermsAndConditions,Accepted")] AdoptionForm adoptionForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionForm.AnimalId);
            return View(adoptionForm);
        }

        // GET: AdoptionForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForm.FindAsync(id);
            if (adoptionForm == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionForm.AnimalId);
            return View(adoptionForm);
        }

        // POST: AdoptionForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimalId,ApplicationUserId,Date,Cc,Job,MoreAnimals,HowMany,AnimalTypes,FinanciallyStable,HouseType,NumberOfBedrooms,NumberOfPeople,AnimalTravel,LeaveHouse,Conscious,TermsAndConditions,Accepted")] AdoptionForm adoptionForm)
        {
            if (id != adoptionForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionFormExists(adoptionForm.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Id", adoptionForm.AnimalId);
            return View(adoptionForm);
        }

        // GET: AdoptionForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForm
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionForm == null)
            {
                return NotFound();
            }

            return View(adoptionForm);
        }

        // POST: AdoptionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionForm = await _context.AdoptionForm.FindAsync(id);
            _context.AdoptionForm.Remove(adoptionForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionFormExists(int id)
        {
            return _context.AdoptionForm.Any(e => e.Id == id);
        }
    }
}
