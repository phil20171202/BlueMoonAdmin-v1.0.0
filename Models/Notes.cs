using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Notes")]
        public string notes { get; set; }

        [Display(Name = "Engineer name")]
        public string EngineerName { get; set; }

        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

        public string Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }

        // might want to link to Signed on user, so you know who added the note
    }
}
