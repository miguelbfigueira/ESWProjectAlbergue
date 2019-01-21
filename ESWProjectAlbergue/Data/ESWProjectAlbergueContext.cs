using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;

namespace ESWProjectAlbergue.Models
{
    public class ESWProjectAlbergueContext : IdentityDbContext<ApplicationUser>
    {
        public ESWProjectAlbergueContext(DbContextOptions<ESWProjectAlbergueContext> options)
            : base(options)
        {
        }



        // Add your customizations after calling base.OnModelCreating(builder);

   
        public DbSet<ESWProjectAlbergue.Models.ApplicationUser> User { get; set; }
        public DbSet<ESWProjectAlbergue.Models.Reminder> Reminder { get; set; }
    }
}

