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
        public DbSet<ESWProjectAlbergue.Models.Visit> Visit { get; set; }
        public DbSet<ESWProjectAlbergue.Models.Animal> Animal { get; set; }
        public DbSet<ESWProjectAlbergue.Models.AnimalBreed> AnimalBreed { get; set; }
        public DbSet<ESWProjectAlbergue.Models.AdoptionFile> AdoptionFile { get; set; }
        public DbSet<ESWProjectAlbergue.Models.AdoptionForm> AdoptionForm { get; set; }
        public DbSet<ESWProjectAlbergue.Models.PosConditionsForm> PosConditionsForm { get; set; }
        public DbSet<ESWProjectAlbergue.Models.PerfectAnimal> PerfectAnimal { get; set; }

    }
}

