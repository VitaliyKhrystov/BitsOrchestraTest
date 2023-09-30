using CsvHelper.Configuration.Attributes;
using System.ComponentModel;

namespace BitsOrchestraTest.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateofBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
