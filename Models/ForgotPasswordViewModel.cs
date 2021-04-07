using System.ComponentModel.DataAnnotations;

namespace BlueMoonAdmin.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
