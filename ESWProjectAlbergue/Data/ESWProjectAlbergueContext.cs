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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalBreed>().HasData(
                new AnimalBreed
                {
                    Id = 1,
                    Name = "Indefinida",
                    Behavior = EnumBehaviorType.ACTIVE


                },

                new AnimalBreed
                {
                    Id = 2,
                    Name = "Beagle",
                    Behavior = EnumBehaviorType.CALM


                },

                new AnimalBreed
                {
                    Id = 3,
                    Name = "Husky",
                    Behavior = EnumBehaviorType.VERYACTIVE


                },

                new AnimalBreed
                {
                    Id = 4,
                    Name = "Labrador",
                    Behavior = EnumBehaviorType.PLAYFUL


                }
             );

        }
    }
}

