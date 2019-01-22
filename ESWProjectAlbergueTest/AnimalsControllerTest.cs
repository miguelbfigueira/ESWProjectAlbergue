using ESWProjectAlbergue.Controllers;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
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
    public class AnimalsControllerTest
    {
        public ESWProjectAlbergueContext DbContext { get; private set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public AnimalsControllerTest()
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
            var controller = new AnimalsController(DbContext);

            var result = controller.Index();

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Delete_ReturnsTask()
        {
            var controller = new AnimalsController(DbContext);

            var result = controller.Delete(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Create_ReturnsTask()
        {
            var controller = new AnimalsController(DbContext);
            Animal animal = new Animal();
            var result = controller.Create(animal);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Edit_ReturnsResult()
        {
            var controller = new AnimalsController(DbContext);
            Animal animal = new Animal();
            var result = controller.Edit(1, animal);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


        [Fact]
        public void Details_ReturnsTask()
        {
            var controller = new AnimalsController(DbContext);
            Animal animal = new Animal();
            var result = controller.Details(1);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
