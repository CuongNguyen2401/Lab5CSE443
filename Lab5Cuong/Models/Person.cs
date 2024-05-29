using System.ComponentModel.DataAnnotations;

namespace Lab5Cuong.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
