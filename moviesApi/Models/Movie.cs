using System.ComponentModel.DataAnnotations.Schema;

namespace moviesApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int year { get; set; }
        public double rate { get; set; }      
        public string storeLine { get; set; }
        public byte[] data { get; set; }

       
        public byte genraId { get; set; }   

        public genra genra { get; set; }    

    }
}
