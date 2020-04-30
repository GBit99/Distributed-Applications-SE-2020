using MC.Models.Entities;
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
    }
}
