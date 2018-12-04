using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESWProjectAlbergue.Models;

namespace ESWProjectAlbergue.Controllers
{
    public class HomeController : Controller
    {
        private ESWProjectAlbergueContext _context;
        public HomeController(ESWProjectAlbergueContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult About()
        {
            ViewData["Message"] = "Sobre nos";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
