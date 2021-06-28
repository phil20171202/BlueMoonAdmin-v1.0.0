using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine { get; set; }

        [Display(Name = "City / Region")]
        public string CityRegion { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public string Website { get; set; }

        [Display(Name = "Customer Since")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> CustomerSince { get; set; }

        [Display(Name = "Vat Reg")]
        public string Vat { get; set; }

        public bool WasLead { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}