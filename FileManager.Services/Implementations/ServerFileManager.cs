using FileManager.Services.Interfaces;
using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Implementations
{
    public class ServerFileManager : IFileManager
    {
        private readonly IServerFolderConfig folderConfig;
        private string  hostEnvironment;
        public ServerFileManager(IServerFolderConfig _folderConfig, string _hostEnvironment)
        {
            folderConfig = _folderConfig;
            hostEnvironment = _hostEnvironment;
        }
        public async Task<ServiceResultViewModel> SaveToStorage(Guid submissionId, List<IFormFile> model)
        {
            ServiceResultViewModel fileSaveResult = new ServiceResultViewModel();
            List<dynamic> fileNames = new List<dynamic>();

            try
            {
                foreach (var item in model)
                {
                    // save to folder
                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = $"{Convert.ToString(Guid.NewGuid())}_{item.FileName}";

                    // Combines two strings into a path.
                    var directoryInfo = Directory.CreateDirectory(hostEnvironment + $@"\{folderConfig.Folder}\{submissionId}\");
                    var filepath = directoryInfo.FullName + $"{myUniqueFileName}";


                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        await item.CopyToAsync(fs);
                        fs.Flush();
                    }
                    fileNames.Add(new FileViewModel { Name = item.FileName.Split('.')[0], UniqueName = myUniqueFileName });
                }

                fileSaveResult.Success = true;
                fileSaveResult.Message = "Files saved successfully";
                fileSaveResult.Data = fileNames;


            }
            catch (Exception ex)
            {
                fileSaveResult.Message = "Error saving files on server";
                fileSaveResult.Data = ex.Message;                
            }


            return fileSaveResult;
        }
    }
}
