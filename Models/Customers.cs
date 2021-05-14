using System;
using System.ComponentModel.DataAnnotations;

namespace BlueMoonAdmin.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

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

        [Display(Name = "Service Contract")]
        public string ServiceContract { get; set; }

        [Display(Name = "Last Service Date")]
        public DateTime LastServiceDate { get; set; }

        [Display(Name = "Current Machine")]
        public string CurrentMachine { get; set; }

        [Display(Name = "Customer Notes")]
        public string CustomerNotes { get; set; }

        [Display(Name = "Customer Since")]
        public DateTime CustomerSince { get; set; }
    }
}