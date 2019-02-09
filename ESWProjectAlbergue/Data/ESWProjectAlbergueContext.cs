// ***********************************************************************
// Assembly         : ESWProjectAlbergue
// Author           : migue
// Created          : 12-08-2018
//
// Last Modified By : migue
// Last Modified On : 02-08-2019
// ***********************************************************************
// <copyright file="ESWProjectAlbergueContext.cs" company="ESWProjectAlbergue">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESWProjectAlbergue.Models;

namespace ESWProjectAlbergue.Models
{
    /// <summary>
    /// Class ESWProjectAlbergueContext.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{ESWProjectAlbergue.Models.ApplicationUser}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{ESWProjectAlbergue.Models.ApplicationUser}" />
    public class ESWProjectAlbergueContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ESWProjectAlbergueContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ESWProjectAlbergueContext(DbContextOptions<ESWProjectAlbergueContext> options)
            : base(options)
        {
        }



        // Add your customizations after calling base.OnModelCreating(builder);


        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public DbSet<ESWProjectAlbergue.Models.ApplicationUser> User { get; set; }
        /// <summary>
        /// Gets or sets the reminder.
        /// </summary>
        /// <value>The reminder.</value>
        public DbSet<ESWProjectAlbergue.Models.Reminder> Reminder { get; set; }
        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        /// <value>The visit.</value>
        public DbSet<ESWProjectAlbergue.Models.Visit> Visit { get; set; }
        /// <summary>
        /// Gets or sets the animal.
        /// </summary>
        /// <value>The animal.</value>
        public DbSet<ESWProjectAlbergue.Models.Animal> Animal { get; set; }
        /// <summary>
        /// Gets or sets the animal breed.
        /// </summary>
        /// <value>The animal breed.</value>
        public DbSet<ESWProjectAlbergue.Models.AnimalBreed> AnimalBreed { get; set; }
        /// <summary>
        /// Gets or sets the adoption file.
        /// </summary>
        /// <value>The adoption file.</value>
        public DbSet<ESWProjectAlbergue.Models.AdoptionFile> AdoptionFile { get; set; }
        /// <summary>
        /// Gets or sets the adoption form.
        /// </summary>
        /// <value>The adoption form.</value>
        public DbSet<ESWProjectAlbergue.Models.AdoptionForm> AdoptionForm { get; set; }
        /// <summary>
        /// Gets or sets the position conditions form.
        /// </summary>
        /// <value>The position conditions form.</value>
        public DbSet<ESWProjectAlbergue.Models.PosConditionsForm> PosConditionsForm { get; set; }
        /// <summary>
        /// Gets or sets the perfect animal.
        /// </summary>
        /// <value>The perfect animal.</value>
        public DbSet<ESWProjectAlbergue.Models.PerfectAnimal> PerfectAnimal { get; set; }


        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
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

