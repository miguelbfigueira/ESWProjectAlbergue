using ESWProjectAlbergue.Controllers;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace ESWProjectAlbergueTest
{
 
    public class HomeControllerTest
    {
        public ESWProjectAlbergueContext context { get; private set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ApplicationUser> _logger;

        public HomeControllerTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ESWProjectAlbergueContext>()
                    .UseSqlite(connection)
                    .Options;
            context = new ESWProjectAlbergueContext(options);

            context.Database.EnsureCreated();


            context.SaveChanges();
            _userManager = null;
            _signInManager = null;
            _emailSender = null;
            _logger = null;
        } 
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new HomeController(context, _userManager,_signInManager,_emailSender,_logger);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_ReturnsViewResult()
        {
            var controller = new HomeController(context, _userManager, _signInManager, _emailSender, _logger);

            var result = controller.About();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void About_SetsMessageInViewData()
        {
            var controller = new HomeController(context, _userManager, _signInManager, _emailSender, _logger);

            controller.About();

            Assert.NotNull(controller.ViewData["Message"]);
        }

        [Fact]
        public void Delete_ReturnsTask()
        {
            var controller = new HomeController(context, _userManager, _signInManager, _emailSender, _logger);
            ApplicationUser u = new ApplicationUser();
            var result = controller.Delete(u.Id);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Edit_ReturnsTask()
        {
            var controller = new HomeController(context, _userManager, _signInManager, _emailSender, _logger);
            ApplicationUser u = new ApplicationUser();
            var result = controller.Edit(u.Id);

            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
