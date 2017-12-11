using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Comment>()
                .HasOne(c=> c.Announcement)
                .WithMany(an => an.Comments)
                .HasForeignKey(c => c.AnnouncementForeignKey);

            builder.Entity<Announcement>()
                .HasOne(an => an.ApplicationUser)
                .WithMany(au => au.Announcements)
                .HasForeignKey(an => an.ApplicationUserForeignKey);

            builder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(au => au.Comments)
                .HasForeignKey(c => c.ApplicationUserForeignKey);
        }

        public DbSet<WebApplication2.Models.Announcement> Announcement { get; set; }

        public DbSet<WebApplication2.Models.Comment> Comment { get; set; }
    }
}
