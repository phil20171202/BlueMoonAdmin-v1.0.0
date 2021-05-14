using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMoonAdmin.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Phone]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Department")]
        public string ContactDepartment { get; set; }

        [Display(Name = "Primary Contact")]
        public bool PrimaryContact { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }

    }
}