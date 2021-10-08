using FileManager.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FileManager.API.Services
{

public interface ISubmissionService
{

        Task<ServiceResultViewModel> AddSubmission(SubmissionViewModel model);

      //Submission GetSubmissionById(Guid submissionId);
      
      //IEnumerable<Submission> GetSubmissions(int count);
    
}

}