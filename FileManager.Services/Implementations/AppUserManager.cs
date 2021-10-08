using FileManager.Data;
using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Implementations
{
    public class AppUserManager
    {
        private readonly UserManager<AppUser> userManager;
        public AppUserManager(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
        }



        public async Task<ServiceResultViewModel> CreateUser(RegistrationViewModel model)
        {
            ServiceResultViewModel result = new ServiceResultViewModel();
            try
            {

                AppUser user = new AppUser { UserName = model.Email, Email = model.Email };
                IdentityResult identityResult = await userManager.CreateAsync(user, model.Password);
                result.Success = identityResult.Succeeded;

                if (result.Success)
                {
                    result.Message = "User Created";
                }
                else
                {
                    result.Message = "Error creating user";
                    List<string> errorList = new List<string>();

                    foreach (IdentityError err in identityResult.Errors)
                    {
                        errorList.Add(err.Description);
                    }

                    result.Data = errorList;
                }

            }
            catch (Exception ex)
            {
                // log exception
                result.Message = ex.Message;

            }
            return result;
        }

    }
}
