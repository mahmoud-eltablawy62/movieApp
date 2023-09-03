using Microsoft.EntityFrameworkCore;
using moviesApi.Models;
using System.Text.RegularExpressions;

namespace moviesApi.services
{
    public class MovieServ : IMovieServ
    {

        private readonly MovieDbContext _Context;

        public MovieServ(MovieDbContext context)
        {
            _Context = context;
        }

        async Task<Movie> IMovieServ.Add(Movie movie)
        {
            await _Context.AddAsync(movie);
            _Context.SaveChanges();
            return movie;

        }

        Movie IMovieServ.Delete(Movie movie)
        {
            _Context.Remove(movie);
            _Context.SaveChanges();
            return movie;   
        }

        async Task <IEnumerable <Movie>> IMovieServ.GetAll()
        {
            return await _Context.Movies.OrderByDescending(R => R.rate).Include(m => m.genra).ToListAsync();
        }

         async Task<Movie> IMovieServ.GetById(int id)
        {
            return await  _Context.Movies.Include(g => g.genra).SingleOrDefaultAsync(m => m.Id == id);
        }

        Movie IMovieServ.update(Movie movie)
        {
            _Context.SaveChanges();
            return movie;   
        }
    }
}
