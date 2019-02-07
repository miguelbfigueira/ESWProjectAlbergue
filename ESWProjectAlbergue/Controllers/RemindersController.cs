﻿using System;
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
    public class RemindersController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        // private readonly RoleManager<ApplicationUser> _userRole;

        public RemindersController(ESWProjectAlbergueContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
       
        }

        // GET: Reminders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reminder.Include(c => c.UserReminderId).Include(r => r.UserCreaterId).ToListAsync());
        }

        // GET: Reminders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .FirstOrDefaultAsync(m => m.ReminderId == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
           
            ViewBag.users = new SelectList(_userManager.Users.ToList());            
            return View();
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReminderId,DateEnd,Title,Description,IsEvent,IsDone, UserReminderId")] Reminder reminder)
        {
            reminder.UserCreaterId = await _userManager.FindByNameAsync(User.Identity.Name);
            reminder.DateCreate = DateTime.Now;
            reminder.UserReminderId = await _userManager.FindByEmailAsync(reminder.UserReminderId.Email);
            reminder.IsDone = false;
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();
                Console.WriteLine(reminder.UserReminderId.Email);

                await _emailSender.SendEmailAsync(reminder.UserReminderId.Email, "Novo Lembrete",
                   $"<h1> Novo Lembrete </h1> " +
                   $"<h4> Tem um novo lembrete </h4> " +
                   $"<p> {reminder.Title} - {reminder.DateEnd} </p> " +
                   $"<p> {reminder.Description} </p>");
                return RedirectToAction(nameof(Index));
            }
           
            return View(reminder);
        }

        // GET: Reminders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }
            ViewBag.users = new SelectList(_userManager.Users.ToList());
            return View(reminder);
        }

        // POST: Reminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReminderId,DateCreate,DateEnd,Title,Description,IsEvent,IsDone,UserReminderId")] Reminder reminder)
        {
            if (id != reminder.ReminderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reminder.UserReminderId = await _userManager.FindByEmailAsync(reminder.UserReminderId.Email);
                    _context.Update(reminder);
                    await _context.SaveChangesAsync();
                    await _emailSender.SendEmailAsync(reminder.UserReminderId.Email, "ATUALIZAÇÃO! - Lembrete",
                  $"<h1> Atualização Lembrete </h1> " +
                  $"<h4> O seu lembrete foi atualizado </h4> " +
                  $"<p> {reminder.Title} - {reminder.DateEnd} </p> " +
                  $"<p> {reminder.Description} </p>");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReminderExists(reminder.ReminderId))
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
            return View(reminder);
        }

        // GET: Reminders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .FirstOrDefaultAsync(m => m.ReminderId == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // POST: Reminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reminder = await _context.Reminder.FindAsync(id);
            _context.Reminder.Remove(reminder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReminderExists(int id)
        {
            return _context.Reminder.Any(e => e.ReminderId == id);
        }
    }
}
