using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlueMoonAdmin.Models
{
    public class Leads
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

        [Phone]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Web Address")]
        public string Website { get; set; }

        [Display(Name = "Vat Reg")]
        public string Vat { get; set; }

        [Display(Name = "Lead Since")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> LeadSince { get; set; }
    }
}

