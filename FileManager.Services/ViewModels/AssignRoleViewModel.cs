using System;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Services.ViewModels
{
    public class AssignRoleViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}