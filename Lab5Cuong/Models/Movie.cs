using System.ComponentModel.DataAnnotations;

namespace Lab5Cuong.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required, Range(0, double.MaxValue)]
        public double Price { get; set; }
        //*****
        [Required, Range(0, 5)]
        public double Rating { get; set; }
        public int ProducerId { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public MovieRole Role { get; set; } 
        public ICollection<Member> Members { get; set; }
        public enum MovieRole
        {
            Actor,
            Director,
            Producer
        }
       
    }
}
