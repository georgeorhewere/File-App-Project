using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface IFileManager
    {
        Task<ServiceResultViewModel> SaveToStorage(Guid submissionId, List<IFormFile> model);
    }
}
