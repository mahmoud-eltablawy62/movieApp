
using System.ComponentModel.DataAnnotations.Schema;

namespace moviesApi.Models
{
    public class genra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }      
    }
}
