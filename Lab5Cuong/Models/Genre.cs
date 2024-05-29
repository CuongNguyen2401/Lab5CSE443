using System.ComponentModel.DataAnnotations;

namespace Lab5Cuong.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}