using ESWProjectAlbergue.Controllers;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESWProjectAlbergueTest
{
    public class AdoptionFilesControllerTest
    {
        public ESWProjectAlbergueContext DbContext { get; private set; }

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IEmailSender _emailSender;

        public AdoptionFilesControllerTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ESWProjectAlbergueContext>().UseSqlite(connection).Options;
            DbContext = new ESWProjectAlbergueContext(options);
            DbContext.Database.EnsureCreated();
        }



        [Fact]
        public void Index_ReturnsTask()
        {
            var controller = new AdoptionFilesController(DbContext, _userManager, _emailSender);

            var result = controller.Index();

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Delete_ReturnsTask()
        {
            var controller = new AdoptionFilesController(DbContext, _userManager, _emailSender);

            var result = controller.Delete(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

       

        [Fact]
        public void Edit_ReturnsResult()
        {
            var controller = new AdoptionFilesController(DbContext, _userManager, _emailSender);
            AdoptionFile adoptionFile = new AdoptionFile();
            var result = controller.Edit(1, adoptionFile);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


        [Fact]
        public void Details_ReturnsTask()
        {
            var controller = new AdoptionFilesController(DbContext, _userManager, _emailSender);
            AdoptionFile adoptionFile = new AdoptionFile();
            var result = controller.Details(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}

