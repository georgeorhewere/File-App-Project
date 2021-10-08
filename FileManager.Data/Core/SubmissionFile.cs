using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Data
{
    public class SubmissionFile
    {
        [Key]
        public Guid SubmissionFileId { get; set; }
        public Guid TransactionId { get; set; }
        public string Name { get; set; }
        
        
    }
}