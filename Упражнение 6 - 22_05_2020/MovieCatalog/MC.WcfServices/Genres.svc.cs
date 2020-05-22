using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Genres" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Genres.svc or Genres.svc.cs at the Solution Explorer and start debugging.
    public class Genres : IGenres
    {
        private readonly GenreService genreService = new GenreService();

        public IEnumerable<GenreDto> GetAllByName(string name)
        {
            return genreService.GetAllByName(name);
        }

        public IEnumerable<GenreDto> GetAll()
        {
            return genreService.GetAll();
        }

        public GenreDto GetById(int genreId)
        {
            return genreService.GetById(genreId);
        }

        public string Create(GenreDto genre)
        {
            if (!genre.IsValid())
            {
                return "Invalid genre";
            }

            bool isCreated = genreService.Create(genre);

            return isCreated ? "Genre added successfully." : "Failed to create the genre.";
        }

        public string Update(GenreDto genre)
        {
            if (!genre.IsValid())
            {
                return "Invalid genre";
            }

            bool isUpdated = genreService.Update(genre);

            return isUpdated ? "Genre updated successfully." : "Failed to update the genre";
        }

        public string Delete(int genreId)
        {
            bool isDeleted = genreService.Delete(genreId);

            return isDeleted ? "Genre deleted successfully." : "Failed to delete the genre.";
        }
    }
}
