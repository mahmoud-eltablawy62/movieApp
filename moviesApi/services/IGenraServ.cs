using moviesApi.Models;

namespace moviesApi.services
{
    public interface IGenraServ
    {
        Task<IEnumerable<genra>> GetAll();
        Task <genra> GetById(byte id);   
        Task <bool> is_Valid (byte id); 
        Task <genra> Add(genra genra);   
        genra Update(genra genra );
        genra Delete(genra genra);
    }
}
