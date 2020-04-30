using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    public class Movies : IMovies
    {
        private readonly MovieService movieService = new MovieService();

        public IEnumerable<MovieDto> GetAll()
        {
            return movieService.GetAll();
        }

        public MovieDto GetById(int movieId)
        {
            return movieService.GetById(movieId);
        }

        public string Create(MovieDto movie)
        {
            bool isCreated = movieService.Create(movie);

            return isCreated ? "Movie added successfully." : "Failed to create the movie.";
        }

        public string Update(MovieDto movie)
        {
            bool isUpdated = movieService.Update(movie);

            return isUpdated ? "Movie updated successfully." : "Failed to update the movie";
        }

        public string Delete(int movieId)
        {
            bool isDeleted = movieService.Delete(movieId);

            return isDeleted ? "Movie deleted successfully." : "Failed to delete the movie.";
        }
    }
}
