using System.Collections.Generic;
using System.ServiceModel;
using MC.Business.DTOs;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IMovies
    {
        [OperationContract]
        IEnumerable<MovieDto> GetAll();

        [OperationContract]
        MovieDto GetById(int movieId);

        [OperationContract]
        string Create(MovieDto movie);

        [OperationContract]
        string Update(MovieDto movie);

        [OperationContract]
        string Delete(int movieId);
    }
}
