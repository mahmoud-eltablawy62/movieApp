using moviesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviesApi.dtos
{
    public class movieDto
    {
        public string Title { get; set; }
        public int year { get; set; }
        public double rate { get; set; }
        public string storeLine { get; set; }
        public IFormFile ? data { get; set; }

        public byte genraId { get; set; }

        
    }
}
