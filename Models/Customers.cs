using System.ComponentModel.DataAnnotations;

namespace BlueMoonAdmin.Models
{
    public class Customers
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string Age { get; set; }
        
        [Display(Name = "Start date")]
        public string StartDate { get; set; }
        public string Salary { get; set; }
    }
}
