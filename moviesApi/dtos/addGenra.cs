namespace moviesApi.dtos
{
    public class addGenra
    { 
        [MaxLength(50)]
        public string Name { get; set; }    
    }
}
