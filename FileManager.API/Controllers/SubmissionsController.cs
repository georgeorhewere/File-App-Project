using FileManager.API.Services;
using FileManager.Services.Implementations;
using FileManager.Services.Interfaces;
using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly IServerFolderConfig folderConfig;
        private IWebHostEnvironment hostEnvironment;
        private readonly ISubmissionService submissionService;
        public SubmissionsController(IServerFolderConfig _folderConfig, 
                        IWebHostEnvironment _hostEnvironment,
                        ISubmissionService _submissionService
            )
        {
            folderConfig = _folderConfig;
            hostEnvironment = _hostEnvironment;
            submissionService = _submissionService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromForm]FileSubmissionViewModel model)
        {

            IFileManager fileManager = new ServerFileManager(folderConfig,hostEnvironment.ContentRootPath);
            var submissionId = Guid.NewGuid();
            var result = await fileManager.SaveToStorage(submissionId, model.SubmissionFiles);           

            if (result.Success)
            {
                List<FileViewModel> savedFiles = new List<FileViewModel>();
                foreach (var item in result.Data)
                    savedFiles.Add(new FileViewModel { Name = item.Name, UniqueName = item.UniqueName });

                // save dbinfo
                var viewModel = new SubmissionViewModel
                {
                    TransactionId = submissionId,
                    VendorName = model.VendorName,
                    SubjectMatter = model.SubjectMatter,
                    SubmissionFiles = savedFiles
                };

                var submissionResult = await submissionService.AddSubmission(viewModel);
                return submissionResult.Success ? Ok(submissionResult) : StatusCode(500, submissionResult);

            }
            else
            {
                return StatusCode(500, result);
            }


            

            




        }


        [HttpPost]
        [Route("GetSubmissions")]
        [Authorize]
        public async Task<IActionResult> Submissions([FromBody] SearchSubmissionViewModel model)
        {
            try
            {
                var submissions = await submissionService.GetSubmissions(model.Search, model.Page, model.Take);
                return Ok(submissions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unexpected server error");

                throw;
            }
        }

    }
}
