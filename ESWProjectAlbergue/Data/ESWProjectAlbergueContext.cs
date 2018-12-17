using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;
using Microsoft.AspNetCore.Identity;

namespace ESWProjectAlbergue.Models
{
    public class ESWProjectAlbergueContext : IdentityDbContext<ApplicationUser> 
    {
        public ESWProjectAlbergueContext(DbContextOptions<ESWProjectAlbergueContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>(userRole =>
            {
             
            });
        }
     // Add your customizations after calling base.OnModelCreating(builder);


        public DbSet<ESWProjectAlbergue.Models.User> User { get; set; }
     // Add your customizations after calling base.OnModelCreating(builder);


        public DbSet<ESWProjectAlbergue.Models.Reminder> Reminder { get; set; }
    }
}
