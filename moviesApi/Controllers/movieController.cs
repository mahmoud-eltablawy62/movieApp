
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviesApi.dtos;
using moviesApi.Models;
using moviesApi.services;

namespace moviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieController : ControllerBase

    {
        private new readonly List<string> AllowExtenstion = new List<string> { ".jpg", ".png" };
        private long max_size = 209752 * 7;
        
       
        private readonly IMovieServ _Context;
        private readonly IGenraServ _Cont;

        public movieController(IMovieServ context  , IGenraServ con ) {
            _Context = context;
            _Cont = con;
        
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var movie = await _Context.GetAll();
            
            return Ok(movie);

        }


        [HttpGet("{ID}")]
        public async Task<IActionResult> getbyId(int id)
        {
            var movie = await _Context.GetById(id);

            if (movie == null)
                return BadRequest("not found");

            return Ok(movie);

        }
     

        [HttpPost]
        public  async Task <IActionResult> Add( [FromForm] movieDto dto ){

            if(dto.data == null)
            return BadRequest("Poster Not Found"); 

            if (!AllowExtenstion.Contains(Path.GetExtension(dto.data.FileName).ToLower()))
                return BadRequest("the page not support is type of photo");

            if (dto.data.Length > max_size)
                return BadRequest("upload photo has 2mB");

            var genra = await _Cont.is_Valid(dto.genraId);

            if (!genra)
                return BadRequest("ID NOT FOUND");

            using var dataStream = new MemoryStream();  
            await dto.data.CopyToAsync( dataStream );   

            var movies = new Movie
            {
                rate = dto.rate,
                genraId = dto.genraId,
                data = dataStream.ToArray(),    
                year = dto.year,
                storeLine = dto.storeLine,
                Title = dto.Title,
            };

            await _Context.Add(movies);
            return Ok(movies);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int id, [FromForm] movieDto dto)
        {
            var movie = await _Context.GetById(id);
            if (movie == null) return BadRequest("not found");

            var is_Valid = await _Cont.is_Valid(dto.genraId);
            if (!is_Valid) return BadRequest("not found");

            if (dto.data !=  null) {
                if(!AllowExtenstion.Contains(Path.GetExtension(dto.data.FileName).ToLower()))
                return BadRequest("the page not support is type of photo");
                if (dto.data.Length > max_size)
                    return BadRequest("upload photo has 7mB");
                using var dataStream = new MemoryStream();
                await dto.data.CopyToAsync(dataStream);
            }

            movie.rate = dto.rate;  
            movie.storeLine = dto.storeLine;    
            movie.Title = dto.Title;
            movie.genraId = dto.genraId;
            movie.year = dto.year;

             _Context.Add(movie); 
            return Ok(movie);   

        }
       


        [HttpDelete ("{Id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var movie = await _Context.GetById(id);

            if (movie == null) return BadRequest("not found");

            _Context.Delete(movie);

            return Ok();    

        }

    }
}
