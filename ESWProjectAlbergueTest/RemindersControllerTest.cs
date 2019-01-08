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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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
            var options = new DbContextOptionsBuilder<ESWProjectAlbergueContext>()
                    .UseSqlite(connection)
                    .Options;
            DbContext = new ApplicationDbContext(options);


            DbContext.Database.EnsureCreated();
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new RemindersController(DbContext, _userManager, _emailSender);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

    }
