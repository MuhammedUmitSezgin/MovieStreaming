using System;
using MovieStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieStreaming.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<FavoriteMovie>? FavoriteMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .UseCollation("tr_TR.UTF-8");
        }

    }
}

