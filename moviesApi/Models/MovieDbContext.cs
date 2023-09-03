using Microsoft.EntityFrameworkCore;

namespace moviesApi.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) : base(options) { }
        public DbSet <genra>Genras { get; set; }
        public DbSet <Movie> Movies { get; set;}

    }
    
    


    }

