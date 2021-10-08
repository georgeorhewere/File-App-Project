using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Data
{
    public class Submission
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string SubjectMatter { get; set; }
        public string VendorName { get; set; }
        public ICollection<SubmissionFile> SubmissionFiles {get; set;} 
        
    }
}