using System.Collections.Generic;
using MC.Business.DTOs;
using MC.Business.Services;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Directors" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Directors.svc or Directors.svc.cs at the Solution Explorer and start debugging.
    public class Directors : IDirectors
    {
        private readonly DirectorService directorService = new DirectorService();

        public IEnumerable<DirectorDto> GetAll(string firstName = null)
        {
            return directorService.GetAll(firstName);
        }

        public DirectorDto GetById(int directorId)
        {
            return directorService.GetById(directorId);
        }

        public string Create(DirectorDto director)
        {
            if (!director.IsValid())
            {
                return "Invalid director";
            }

            bool isCreated = directorService.Create(director);

            return isCreated ? "Director added successfully." : "Failed to create the director.";
        }

        public string Update(DirectorDto director)
        {
            if (!director.IsValid())
            {
                return "Invalid director";
            }

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
