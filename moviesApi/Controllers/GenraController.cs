using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviesApi.dtos;
using moviesApi.Models;
using moviesApi.services;

namespace moviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenraController : ControllerBase
    {
        private readonly IGenraServ _serv;
        public GenraController(IGenraServ serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var gen = await _serv.GetAll();
            return Ok(gen);

        }
        [HttpPost]
        public async Task<ActionResult> Add( addGenra dto )
        {
            var genra =  new genra { Name = dto.Name };
             await _serv.Add( genra );      
            return Ok(genra);
        }

        [HttpPut("{Id}")] 
        public async Task<ActionResult> Update (byte id , addGenra dto)
        {
            var genra = await _serv.GetById(id);   
            if (genra == null) {
                return NotFound( $" genra not found when id := {id}");}
            genra.Name = dto.Name;  
            _serv.Update( genra );  
            return Ok(genra);
        }

        [HttpDelete ("{Id}")]
        public async Task<ActionResult> Delete(byte id)
        {
            var genra = await _serv.GetById(id);
            if (genra == null)
            {
                return NotFound($" genra not found when id := {id}");
            }
            _serv.Delete( genra );  
            return Ok(genra);
        }

        
    }
}
