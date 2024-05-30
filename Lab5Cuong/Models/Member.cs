using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5Cuong.Models
{
    [Table("Member")]
    public class Member
    {
        
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public Role MovieRole { get; set; }

        
    }
    public enum Role
    {
        Actor,
        Director,
        Producer
    }
}
