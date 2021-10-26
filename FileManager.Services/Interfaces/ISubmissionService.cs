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
      Task<IEnumerable<SubmissionViewModel>> GetSubmissions(string search, int page, int take);
    
}

}