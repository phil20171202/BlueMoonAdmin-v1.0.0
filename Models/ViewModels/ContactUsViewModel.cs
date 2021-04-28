using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ContactUsViewModel
    {
        [Required, Display(Name = "Your Name")]
        public string SenderName { get; set; }

        [Required, Display(Name = "Your Email"), EmailAddress]
        public string SenderEmail { get; set; }

        [Required, Display(Name = "Telephone Number")]
        public int TelephoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
