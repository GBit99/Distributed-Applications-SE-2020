using System.Collections.Generic;
using System.ServiceModel;
using MC.Business.DTOs;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDirectors" in both code and config file together.
    [ServiceContract]
    public interface IDirectors
    {
        [OperationContract]
        IEnumerable<DirectorDto> GetAllByFirstName(string firstName);

        [OperationContract]
        IEnumerable<DirectorDto> GetAll();

        [OperationContract]
        DirectorDto GetById(int directorId);

        [OperationContract]
        string Create(DirectorDto director);

        [OperationContract]
        string Update(DirectorDto director);

        [OperationContract]
        string Delete(int directorId);
    }
}
