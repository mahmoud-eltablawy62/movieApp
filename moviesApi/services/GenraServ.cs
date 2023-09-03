using Microsoft.EntityFrameworkCore;
using moviesApi.Models;

namespace moviesApi.services
{
    public class GenraServ : IGenraServ
    {
        private readonly MovieDbContext _Context;
        public GenraServ(MovieDbContext Context)
        {
            _Context = Context;
        }
        public async Task<genra> Add(genra Genra)
        {
            await _Context.AddAsync(Genra);
            _Context.SaveChanges();
            return (Genra);
        }



        public async Task<IEnumerable<genra>> GetAll()
        {
            return await _Context.Genras.OrderBy(g => g.Name).ToListAsync();
            
        }

        public async Task<genra> GetById(byte id)
        {
            return  await _Context.Genras.SingleOrDefaultAsync(g => g.Id == id);  
        }

       

        genra IGenraServ.Delete(genra genra)
        {
            _Context.Remove(genra);
            _Context.SaveChanges();
            return (genra);
        }

        

        Task<bool> IGenraServ.is_Valid(byte id)
        {
            return _Context.Genras.AnyAsync(g => g.Id == id);
        }

        genra IGenraServ.Update(genra genra)
        {
            _Context.Update(genra);
            _Context.SaveChanges();
            return (genra);
        }
    }
}
