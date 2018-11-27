using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESWProjectAlbergue.Areas.Identity.Data;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESWProjectAlbergue.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly ESWProjectAlbergueContext _context;
        
        public UtilizadoresController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }

        
        // GET: Utilizadores
        public async Task<ActionResult> Index()
        {
          
            return View((IEnumerable<Utilizador>) _context.Model);
        }

      

        // GET: Utilizadores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utilizadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utilizadores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}