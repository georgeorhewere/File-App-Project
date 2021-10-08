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
                // confirming email and phone at this stage for test purposes. it would not be allowed for production code
                AppUser user = new AppUser { 
                                        UserName = model.Email, 
                                        Email = model.Email, 
                                        FullName=model.FullName, 
                                        PhoneNumber=model.PhoneNumber,
                                        EmailConfirmed = true,
                                        PhoneNumberConfirmed = true,

                                        };

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


        public async Task<ServiceResultViewModel> AssignUserRole(AssignRoleViewModel model)
        {
            ServiceResultViewModel result = new ServiceResultViewModel();

            try
            {
                AppUser user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var currentUserRoles = await userManager.GetRolesAsync(user);
                    if (currentUserRoles.Any())
                    {
                        if (model.IsAdmin)
                        {
                            await AssignAdministratorRole(result, user, currentUserRoles);
                        }
                        else
                        {
                            await AssignUserRole(result, user, currentUserRoles);
                        }
                    }
                    else
                    {
                        result.Message = $"No roles found for this user";
                    }


                }
                else
                {
                    result.Message = $"User not found";
                }
            }
            catch (Exception ex)
            {
                result.Message = "Error assigning user roles";                
            }


            return result;
        }

        private async Task AssignUserRole(ServiceResultViewModel result, AppUser user, IList<string> currentUserRoles)
        {
            if (!currentUserRoles.Any(x => x.Equals(Roles.USERROLE)))
            {
                //remove admin role
                var roleResult = await userManager.RemoveFromRoleAsync(user, Roles.ADMINROLE);
                if (roleResult.Succeeded)
                {
                    //add user role
                    roleResult = await userManager.AddToRoleAsync(user, Roles.USERROLE);
                    result.Success = roleResult.Succeeded;
                    result.Message = roleResult.Succeeded ? $"User assigned standard user role " : $"Unbale to assign standard user role";

                }
                else
                {
                    result.Message = $"Unable to change administrator role";
                }
            }
            else
            {
                result.Success = true;
                result.Message = $"User already assigned standard user role ";
            }
        }

        private async Task AssignAdministratorRole(ServiceResultViewModel result, AppUser user, IList<string> currentUserRoles)
        {
            if (!currentUserRoles.Any(x => x.Equals(Roles.ADMINROLE)))
            {
                //remove user role
                var roleResult = await userManager.RemoveFromRoleAsync(user, Roles.USERROLE);
                if (roleResult.Succeeded)
                {
                    //add admin role
                    roleResult = await userManager.AddToRoleAsync(user, Roles.ADMINROLE);
                    result.Success = roleResult.Succeeded;
                    result.Message = roleResult.Succeeded ? $"User assigned administrator role " : $"Unbale to assigne administrator role";

                }
                else
                {
                    result.Message = $"Unable to change user role";
                }
            }
            else
            {
                result.Success = true;
                result.Message = $"User already assigned administrator user role ";
            }
        }
    }
}
