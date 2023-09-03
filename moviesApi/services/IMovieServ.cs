using moviesApi.Models;

namespace moviesApi.services
{
    public interface IMovieServ
    {
        Task<IEnumerable<Movie>> GetAll();
        Task <Movie> GetById(int id);   
        Task<Movie> Add(Movie movie);
        Movie update (Movie movie);
        Movie Delete (Movie movie); 

    }
}
