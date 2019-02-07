using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ESWProjectAlbergue.Controllers
{
    public class AdoptionFormsController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;


        public AdoptionFormsController(ESWProjectAlbergueContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;

        }

        // GET: AdoptionForms
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.AdoptionForm.Include(a => a.Animal).Include(a => a.ApplicationUser);
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
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.AdoptionFormId == id);
            if (adoptionForm == null)
            {
                return NotFound();
            }

            return View(adoptionForm);
        }

        // GET: AdoptionForms/Create
        public async Task<IActionResult> Create(int? id)
        {
            Animal animal = _context.Animal.FirstOrDefault(a=>a.Id == id);
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
            var user = await _userManager.GetUserAsync(User);
            ViewData["ApplicationUser"] = user.Name;
            AdoptionForm adoption = new AdoptionForm();
            adoption.AnimalId = animal.Id;
            adoption.Animal = animal;
            adoption.ApplicationUserId = user.Id;
            adoption.ApplicationUser = user;
            adoption.Date = DateTime.Now;
           
            return View(adoption);
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", adoptionForm.AnimalId);
            ViewData["ApplicationUserId"] = new SelectList(_context.User, "Id", "Name", adoptionForm.ApplicationUserId);
            return View(adoptionForm);
        }

        // POST: AdoptionForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdoptionFormId,AnimalId,ApplicationUserId,Date,Cc,Job,MoreAnimals,HowMany,AnimalTypes,FinanciallyStable,HouseType,NumberOfBedrooms,NumberOfPeople,AnimalTravel,LeaveHouse,Conscious,Accepted")] AdoptionForm adoptionForm)
        {
            if (id != adoptionForm.AdoptionFormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionForm);
                    await _context.SaveChangesAsync();
                    AdoptionFile adoptionFile = new AdoptionFile { AnimalId = adoptionForm.AnimalId, ApplicationUserId = adoptionForm.ApplicationUserId, Date = DateTime.Now, Status = EnumAdoptionStatus.PENDING, OrderId = adoptionForm.AdoptionFormId };
                    _context.Add(adoptionFile);
                    await _context.SaveChangesAsync();
                    var user = await _userManager.FindByIdAsync(adoptionForm.ApplicationUserId);
                    await _emailSender.SendEmailAsync(user.Email, "Pedido de Adoção",
                   $"<h1> Pedido de Adoção </h1> " +
                   $"<h4> O seu pedido de adoção foi submetido com sucesso. Em breve irá obter a sua resposta. </h4> " );
                  

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionFormExists(adoptionForm.AdoptionFormId))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name", adoptionForm.AnimalId);
            ViewData["ApplicationUserId"] = new SelectList(_context.User, "Id", "Name", adoptionForm.ApplicationUserId);
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
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.AdoptionFormId == id);
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
            return _context.AdoptionForm.Any(e => e.AdoptionFormId == id);
        }
    }
}
