using System.ComponentModel.DataAnnotations;

namespace BitsOrchestraTest.Models
{
    public class PersonModelCrvReader
    {
        public string Name { get; set; }
        public DateOnly DateofBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
