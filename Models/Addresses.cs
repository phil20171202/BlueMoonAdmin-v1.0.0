using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine { get; set; }

        [Display(Name = "City / Region")]
        public string CityRegion { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Phone]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> LastServiceDate { get; set; }

        [Display(Name = "Current Machine")]
        public string CurrentMachine { get; set; }

        [Display(Name = "Customer Notes")]
        public string CustomerNotes { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }
    }
}
