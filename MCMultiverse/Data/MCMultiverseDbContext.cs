using MCMultiverse.Models;
using MCMultiverse.Models.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Data
{
    public class MCMultiverseDbContext : DbContext
    {
        public DbSet<MCServer> MCServers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavoriteServer> Favorites { get; set; }

        public MCMultiverseDbContext(DbContextOptions<MCMultiverseDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FavoriteServer>()
                .HasKey(favorite => new { favorite.UserId, favorite.FK_MCServerId });

            builder.Entity<MCServer>()
                .HasKey(server => server.Id);

            builder.Entity<FavoriteServer>()
                .HasOne(favorite => favorite.MCServer);
        }
    }
}
