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

        [Display(Name = "Contract Type")]
        public String ServiceContract { get; set; }


        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> StartDate { get; set; }

        [Display(Name = "Renewal Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> RenewalDate { get; set; }

        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> LastServiceDate { get; set; }

        [Display(Name = "Next Service Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> NextServiceDate { get; set; }

        [Display(Name = "Current Machine")]
        public string CurrentMachine { get; set; }

        [Display(Name = "Machine Notes")]
        public string MachineNotes { get; set; }

        [Display(Name = "Active Service")]
        public bool Service { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }

    }
}
