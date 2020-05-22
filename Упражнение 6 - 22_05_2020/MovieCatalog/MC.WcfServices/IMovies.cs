using System.Collections.Generic;
using System.ServiceModel;
using MC.Business.DTOs;

namespace MC.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovies" in both code and config file together.
    [ServiceContract]
    public interface IMovies
    {
        [OperationContract]
        IEnumerable<MovieDto> GetAllByTitle(string title);

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
