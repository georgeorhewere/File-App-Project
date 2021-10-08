using System.ComponentModel.DataAnnotations;

namespace FileManager.Services.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}