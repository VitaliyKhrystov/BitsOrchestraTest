using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BitsOrchestraTest.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateofBirth { get; set; }
        public bool Married { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
