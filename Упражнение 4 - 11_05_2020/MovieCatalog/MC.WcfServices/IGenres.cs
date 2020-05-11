using System.Collections.Generic;
using System.ServiceModel;
using MC.Business.DTOs;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGenres" in both code and config file together.
    [ServiceContract]
    public interface IGenres
    {
        [OperationContract]
        IEnumerable<GenreDto> GetAll();

        [OperationContract]
        GenreDto GetById(int genreId);

        [OperationContract]
        string Create(GenreDto genre);

        [OperationContract]
        string Update(GenreDto genre);

        [OperationContract]
        string Delete(int genreId);
    }
}
