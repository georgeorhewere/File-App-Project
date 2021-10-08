using FileManager.API.Services;
using FileManager.Data;
using FileManager.Repository;
using FileManager.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        protected readonly ISubmissionRepository submissionRepository;
        protected readonly ISubmissionFileRepository submissionFileRepository;
        public SubmissionService(ISubmissionRepository _submissionRepository, ISubmissionFileRepository _submissionFileRepository)
        {
            submissionRepository = _submissionRepository;
            submissionFileRepository = _submissionFileRepository;
        }

        public async Task<ServiceResultViewModel> AddSubmission(SubmissionViewModel model)
        {
            ServiceResultViewModel submitResult = new ServiceResultViewModel();
            try
            {   
                // add submission
                Submission entity = new Submission
                {
                    TransactionId = model.TransactionId,
                    SubjectMatter = model.SubjectMatter,
                    VendorName = model.VendorName,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
                
                await submissionRepository.Save(entity);
                // save submission file information
                List<SubmissionFile> submissionFiles = new List<SubmissionFile>();

                foreach(var item in model.SubmissionFiles)
                {
                    var submissionFile = new SubmissionFile
                    {
                        Name = item.Name,
                        UniqueName = item.UniqueName,
                        TransactionId = entity.TransactionId,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now                        
                    };
                    submissionFiles.Add(submissionFile);
                }

                await submissionFileRepository.SaveList(submissionFiles);

                submitResult.Success = true;
                submitResult.Data = new { entity.TransactionId };
                submitResult.Message = $"Submission saved successfully";
            }
            catch (Exception ex)
            {
                submitResult.Message = $"Unexpected error saving suubmission";
            }

            return submitResult;
        }
    }
}
