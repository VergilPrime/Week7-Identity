using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MCMultiverse.Models;
using MCMultiverse.Models.Application;

namespace MCMultiverse.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MCServer> MCServers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Image> Images { get; set; }

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

            builder.Entity<Favorite>()
                .HasKey(favorite => new { favorite.ApplicationUserId, favorite.MCServerId });

            builder.Entity<Favorite>()
                .HasOne(favorite => favorite.MCServer)
                .WithMany()
                .HasForeignKey(favorite => favorite.MCServerId);

            builder.Entity<Favorite>()
                .HasOne(favorite => favorite.ApplicationUser)
                .WithMany(user => user.Favorites)
                .HasForeignKey(favorite => favorite.ApplicationUserId);


            builder.Entity<Vote>()
                .HasOne(vote => vote.ApplicationUser)
                .WithMany(user => user.Votes);

            builder.Entity<Vote>()
                .HasOne(vote => vote.MCServer)
                .WithMany(server => server.Votes);


            builder.Entity<MCServer>()
                .HasMany(server => server.Comments)
                .WithOne(comment => comment.ServerParent);

            builder.Entity<MCServer>()
                .HasMany(server => server.Images)
                .WithOne(image => image.MCServer);

            builder.Entity<MCServer>()
                .HasOne(server => server.Owner)
                .WithMany(user => user.Servers);


            builder.Entity<Comment>()
                .HasMany(comment => comment.Replies)
                .WithOne(comment => comment.CommentParent);
        }
    }
}
