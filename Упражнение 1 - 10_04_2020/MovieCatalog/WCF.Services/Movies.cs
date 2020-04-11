using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    public class Movies : IMovies
    {
        private static List<Movie> movies = new List<Movie>();

        public string Create(Movie movie)
        {
            Movie foundMovie = GetMovie(movie.Id);

            if (foundMovie != null)
            {
                return "Movie id already used.";
            }

            movies.Add(movie);

            return "Movie added successfully.";
        }

        public string Delete(int movieId)
        {
            Movie foundMovie = GetMovie(movieId);

            if (foundMovie == null)
            {
                return "Movie not found.";
            }

            movies.Remove(foundMovie);

            return "Movie removed successfully.";
        }

        public List<Movie> GetAllMovies()
        {
            return movies;
        }

        public Movie GetMovie(int movieId)
        {
            Movie foundMovie = null;

            foreach (var movie in movies)
            {
                if (movie.Id == movieId)
                {
                    foundMovie = movie;
                }
            }

            return foundMovie;
        }

        public string Update(Movie movie)
        {
            Movie foundMovie = GetMovie(movie.Id);

            if (foundMovie == null)
            {
                return "Movie not found.";
            }

            foundMovie.Rating = movie.Rating;
            foundMovie.Title = movie.Title;
            foundMovie.Genre = movie.Genre;

            return "Update successful.";
        }
    }
}
