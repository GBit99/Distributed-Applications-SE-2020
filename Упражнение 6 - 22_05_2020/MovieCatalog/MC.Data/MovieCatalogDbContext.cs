﻿using MC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC.Data
{
    public class MovieCatalogDbContext : DbContext
    {
        public MovieCatalogDbContext() : base()
        { }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=.;" +
                              @"DataBase=MovieCatalog;" +
                              @"Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
