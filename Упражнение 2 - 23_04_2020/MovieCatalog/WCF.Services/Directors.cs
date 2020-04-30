using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Directors" in both code and config file together.
    public class Directors : IDirectors
    {
        private readonly DirectorService directorService = new DirectorService();

        public IEnumerable<DirectorDto> GetAll()
        {
            return directorService.GetAll();
        }

        public DirectorDto GetById(int directorId)
        {
            return directorService.GetById(directorId);
        }

        public string Create(DirectorDto director)
        {
            bool isCreated = directorService.Create(director);

            return isCreated ? "Director added successfully." : "Failed to create the director.";
        }

        public string Update(DirectorDto director)
        {
            bool isUpdated = directorService.Update(director);

            return isUpdated ? "Director updated successfully." : "Failed to update the director";
        }

        public string Delete(int directorId)
        {
            bool isDeleted = directorService.Delete(directorId);

            return isDeleted ? "Director deleted successfully." : "Failed to delete the director.";
        }
    }
}
