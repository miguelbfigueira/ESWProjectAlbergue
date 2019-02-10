using ESWProjectAlbergue.Controllers;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ESWProjectAlbergueTest
{
    public class RemindersControllerTest
    {
        public ESWProjectAlbergueContext DbContext { get; private set; }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

       public RemindersControllerTest()
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
            var controller = new RemindersController(DbContext, _userManager, _emailSender);

            var result = controller.Index();

            var viewResult = Assert.IsType<Task<IActionResult >>(result);
        }

        [Fact]
        public void Edit_ReturnsTask()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);

            var result = controller.Edit(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
        
        [Fact]
        public void Delete_ReturnsTask()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);

            var result = controller.Delete(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Create_ReturnsTask()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);
            Reminder reminder = new Reminder();
            var result = controller.Create(reminder);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Edit_ReturnsResult()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);
            Reminder reminder = new Reminder();
            var result = controller.Edit(1, reminder);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


        [Fact]
        public void Details_ReturnsTask()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);
            Reminder reminder = new Reminder();
            var result = controller.Details(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


    }
}
