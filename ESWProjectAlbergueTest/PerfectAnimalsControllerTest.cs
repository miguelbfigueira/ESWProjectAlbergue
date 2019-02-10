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
    public class PerfectAnimalsControllerTest
    {

        public ESWProjectAlbergueContext DbContext { get; private set; }

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IEmailSender _emailSender;

        public PerfectAnimalsControllerTest()
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
            var controller = new PerfectAnimalsController(DbContext);

            var result = controller.Index();

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void GetAnimalIdeal_ReturnsTask()
        {
            var controller = new PerfectAnimalsController(DbContext);
            PerfectAnimal perfectAnimal = new PerfectAnimal();
            var result = controller.GetAnimalIdeal(perfectAnimal);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void HowPerfect_ReturnsPercentagem()
        {
            var controller = new PerfectAnimalsController(DbContext);
            PerfectAnimal perfectAnimal = new PerfectAnimal() { Age = EnumAgeType.BABY};
            Animal animal = new Animal() { AgeType = EnumAgeType.BABY };
            var result = controller.HowPerfect(perfectAnimal, animal);

            PerfectAnimal perfect = new PerfectAnimal() { Percentagem = 20 };


             Assert.True(perfect.Percentagem.Equals(perfectAnimal.Percentagem));
        }

        [Fact]
        public void Delete_ReturnsTask()
        {
            var controller = new PerfectAnimalsController(DbContext);

            var result = controller.Delete(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }



        [Fact]
        public void Edit_ReturnsResult()
        {
            var controller = new PerfectAnimalsController(DbContext);
            PerfectAnimal perfectAnimal = new PerfectAnimal();
            var result = controller.Edit(1, perfectAnimal);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


        [Fact]
        public void Details_ReturnsTask()
        {
            var controller = new PerfectAnimalsController(DbContext);
            PerfectAnimal perfectAnimal = new PerfectAnimal();
            var result = controller.Details(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

    }
}
