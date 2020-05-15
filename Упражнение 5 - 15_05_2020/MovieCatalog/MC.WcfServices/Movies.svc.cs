using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Movies" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Movies.svc or Movies.svc.cs at the Solution Explorer and start debugging.
    public class Movies : IMovies
    {
        private readonly MovieService movieService = new MovieService();

        public IEnumerable<MovieDto> GetAllByTitle(string title)
        {
            return movieService.GetAllByTitle(title);
        }

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
