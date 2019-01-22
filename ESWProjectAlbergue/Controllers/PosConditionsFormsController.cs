using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;

namespace ESWProjectAlbergue.Views
{
    public class PosConditionsFormsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;

        public PosConditionsFormsController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        // GET: PosConditionsForms
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.PosConditionsForm.Include(p => p.AdoptionFile);
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: PosConditionsForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posConditionsForm = await _context.PosConditionsForm
                .Include(p => p.AdoptionFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }

            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Create
        public IActionResult Create()
        {
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id");
            return View();
        }

        // POST: PosConditionsForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdoptionFileId,Answer1,Answer2,Answer3,result")] PosConditionsForm posConditionsForm)
        {
            if (ModelState.IsValid)
            {
                if(posConditionsForm.Answer1 == true && posConditionsForm.Answer2 == true && posConditionsForm.Answer3 == true)
                {
                    posConditionsForm.result = true;
                }
                else
                {
                    posConditionsForm.result = false;
                }
                _context.Add(posConditionsForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posConditionsForm = await _context.PosConditionsForm.FindAsync(id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // POST: PosConditionsForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdoptionFileId,Answer1,Answer2,Answer3,result")] PosConditionsForm posConditionsForm)
        {
            if (id != posConditionsForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (posConditionsForm.Answer1 == true && posConditionsForm.Answer2 == true && posConditionsForm.Answer3 == true)
                    {
                        posConditionsForm.result = true;
                    }
                    else
                    {
                        posConditionsForm.result = false;
                    }
                    _context.Update(posConditionsForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosConditionsFormExists(posConditionsForm.Id))
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
            ViewData["AdoptionFileId"] = new SelectList(_context.AdoptionFile, "Id", "Id", posConditionsForm.AdoptionFileId);
            return View(posConditionsForm);
        }

        // GET: PosConditionsForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posConditionsForm = await _context.PosConditionsForm
                .Include(p => p.AdoptionFile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posConditionsForm == null)
            {
                return NotFound();
            }

            return View(posConditionsForm);
        }

        // POST: PosConditionsForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posConditionsForm = await _context.PosConditionsForm.FindAsync(id);
            _context.PosConditionsForm.Remove(posConditionsForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosConditionsFormExists(int id)
        {
            return _context.PosConditionsForm.Any(e => e.Id == id);
        }
    }
}
