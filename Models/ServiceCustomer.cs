using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models
{
    public class ServiceCustomer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Name")]
        public string ContactName { get; set; }

        [Display(Name = "Telephone Number")]
        public int TelephoneNumber { get; set; }
        
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Renewal date")]
        public DateTime RenewalDate { get; set; }

        [Display(Name = "Last Service Date")]
        public DateTime LastServiceDate { get; set; }

        [Display(Name = "Contract Type")]
        public string ContractType { get; set; }

        [Display(Name = "Current Machine")]
        public string CurrentMachine { get; set; }

    }
}
