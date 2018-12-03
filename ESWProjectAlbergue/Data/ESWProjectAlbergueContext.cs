﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ESWProjectAlbergue.Models.User> User { get; set; }
    }
}