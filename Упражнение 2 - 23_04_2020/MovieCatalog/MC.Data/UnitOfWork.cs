using System;
using MC.Models.Entities;

namespace MC.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly MovieCatalogDbContext dbContext;
        private BaseRepository<Movie> movieRepository;
        private BaseRepository<Director> directorRepository;
        private BaseRepository<Genre> genreRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            this.dbContext = new MovieCatalogDbContext();
            dbContext.Database.EnsureCreated();
        }

        public BaseRepository<Movie> MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new BaseRepository<Movie>(dbContext);
                }

                return movieRepository;
            }
        }

        public BaseRepository<Director> DirectorRepository
        {
            get
            {
                if (this.directorRepository == null)
                {
                    this.directorRepository = new BaseRepository<Director>(dbContext);
                }

                return directorRepository;
            }
        }

        public BaseRepository<Genre> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new BaseRepository<Genre>(dbContext);
                }

                return genreRepository;
            }
        }

        public bool Save()
        {
            try
            {
                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                disposed = true;
            }
        }
    }
}
