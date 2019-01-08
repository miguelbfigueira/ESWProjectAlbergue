using ESWProjectAlbergue.Controllers;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using System.Linq;

using Xunit;


namespace ESWProjectAlbergueTest
{/*
    public class ESWProjectAlbergueContextFixture
    {
        public ESWProjectAlbergueContext DbContext { get; private set; }

        public ESWProjectAlbergueContextFixture()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ESWProjectAlbergueContext>()
                    .UseSqlite(connection)
                    .Options;
            DbContext = new ESWProjectAlbergueContext(options);

            DbContext.Database.EnsureCreated();

           
            DbContext.SaveChanges();    
        }
    }

 
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new HomeController(DbContext,);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_ReturnsViewResult()
        {
            var controller = new HomeController();

            var result = controller.About();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_SetsMessageInViewData()
        {
            var controller = new HomeController();

            controller.About();

            Assert.NotNull(controller.ViewData["Message"]);
        }
    }*/
}
