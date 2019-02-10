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
    /// <summary>
    /// Class AdoptionFilesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AdoptionFilesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ESWProjectAlbergueContext _context;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender _emailSender;
      

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptionFilesController" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="emailSender">The email sender.</param>
        public AdoptionFilesController(ESWProjectAlbergueContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

       

        // GET: AdoptionFiles
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        public async Task<IActionResult> Index()
        {
            var eSWProjectAlbergueContext = _context.AdoptionFile.Include(a => a.Animal).Include(u => u.ApplicationUser);
            ViewData["BreedId"] = new SelectList(_context.Set<AnimalBreed>(), "Id", "Name");
            return View(await eSWProjectAlbergueContext.ToListAsync());
        }

        // GET: AdoptionFiles/Details/5
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

            var adoptionFile = await _context.AdoptionFile
                .Include(a => a.Animal).Include(u => u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionFile == null)
            {
                return NotFound();
            }

            return View(adoptionFile);
        }

        // GET: AdoptionFiles/Edit/5
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

            var adoptionFile = await _context.AdoptionFile.FindAsync(id);
            if (adoptionFile == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = adoptionFile.AnimalId;
            ViewData["AnimalName"] = _context.Animal.Find(adoptionFile.AnimalId).Name;
            ViewData["UserName"] = _context.User.Find(adoptionFile.ApplicationUserId).Name;
            return View(adoptionFile);
        }

        /// <summary>
        /// Edita do ficheiro de adoção e envia um email com as alterações
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="adoptionFile">The adoption file.</param>
        /// <returns>O ficheiro de adoção editado.</returns>
        // POST: AdoptionFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimalId,ApplicationUserId,Status")] AdoptionFile adoptionFile)
        {
            if (id != adoptionFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(adoptionFile.Status == EnumAdoptionStatus.ACEITE)
                    {
                        var animal = _context.Animal.Find(adoptionFile.AnimalId);
                        animal.Adopted= true;
                        _context.Update(animal);
                        await _context.SaveChangesAsync();
                    }
                    var user = await _userManager.FindByIdAsync(adoptionFile.ApplicationUserId);
                    await _emailSender.SendEmailAsync(user.Email, "Pedido de Adoção",
                   $"<h1> Pedido de Adoção </h1> " +
                   $"<h4> O seu pedido de adoção foi "+ adoptionFile.Status );

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

            var adoptionFile = await _context.AdoptionFile
                .Include(a => a.Animal).Include(u=> u.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionFile == null)
            {
                return NotFound();
            }

            return View(adoptionFile);
        }

        // POST: AdoptionFiles/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionFile = await _context.AdoptionFile.FindAsync(id);
            _context.AdoptionFile.Remove(adoptionFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Adoptions the file exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool AdoptionFileExists(int id)
        {
            return _context.AdoptionFile.Any(e => e.Id == id);
        }

        /// <summary>
        /// Filtrar as fichas de adoção pelas raças dos cães
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Um view com os animais da raça selecionada</returns>
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


        /// <summary>
        /// Filtrar as fichas de adoção pelas datas da adoção dos cães
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Um view com os animais adotados na data selecionada</returns>
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
