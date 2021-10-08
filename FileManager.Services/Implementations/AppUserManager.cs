using FileManager.Data;
using FileManager.Data.Utilities;
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
                    //add user to role
                    var roleResult = await userManager.AddToRoleAsync(user, Roles.USERROLE);
                    result.Success = roleResult.Succeeded;
                    if (roleResult.Succeeded)
                    {
                        result.Data = new { user.Id };
                        result.Message = "User Created";
                    }
                    else
                    {
                        // remove user
                        await userManager.DeleteAsync(user);
                        result.Message= "Unable to assign role to user";
                    }                    
                }
                else
                {
                    
                    List<string> errorList = new List<string>();

                    foreach (IdentityError err in identityResult.Errors)
                    {
                        errorList.Add(err.Description);
                    }

                    result.Data = errorList;
                    result.Message = $"Error creating user: {string.Join(',', errorList) }";
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
