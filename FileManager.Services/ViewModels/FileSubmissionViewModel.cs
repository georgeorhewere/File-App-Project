using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Services.ViewModels
{
    public class FileSubmissionViewModel
    {
        [Required]
        public string VendorName { get; set; }
        [Required]
        public string SubjectMatter { get; set; }
        [Required]
        public List<IFormFile> SubmissionFiles { get; set; }   
        

    }

    public class FileViewModel
    {
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string Url { get; set; }
        public string SubmissionFileId { get; set; }

    }

}