using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]        
        public string Password { get; set; }

        [Required]
        [MaxLength(15)] // Maximum allowable length for phone numbers
        [MinLength(10)]
        [Phone]
        public string PhoneNumber { get; set; }

    }
}
