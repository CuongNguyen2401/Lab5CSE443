using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
 

        public List<Member> Members { get; set; }
      
       
    }
}
