using System;
using System.Collections.Generic;

namespace FileManager.Services.ViewModels
{
    public class SubmissionViewModel
    {
        public Guid TransactionId { get; set; }
        public string SubjectMatter { get; set; }
        public string VendorName { get; set; }
        public List<FileViewModel> SubmissionFiles { get; set; }
    }
}