using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMoonAdmin.Models
{
    public class ServiceHistory
    {
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ServiceDate { get; set; }

        [Display(Name = "Engineer Name")]
        public string EngineerName { get; set; }

        [Display(Name = "Service Comments")]
        public string ServceComments { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual ServiceCustomer ServiceCustomer { get; set; }

        
    }
}