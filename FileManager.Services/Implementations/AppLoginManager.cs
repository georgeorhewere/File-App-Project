using FileManager.Data;
using FileManager.Services.Interfaces;
using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileManager.Services.Implementations
{
    public class AppLoginManager
    {
        private readonly SignInManager<AppUser> _signInManager;
        private IJWTConfig _config;
        

        public AppLoginManager(SignInManager<AppUser> signInManager, IJWTConfig config)
        {
            _signInManager = signInManager;
            _config = config;          
        }

        public async Task<ServiceResultViewModel> LoginUser(LoginViewModel model)
        {
            ServiceResultViewModel result = new ServiceResultViewModel();
            try
            {

                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (loginResult.Succeeded)
                {
                    //generate token
                    var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);

                    var claims = new List<Claim>();
                    claims.Add(new Claim("username", model.UserName));

                    // Add roles as multiple claims
                    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    //generate token                
                    result.Data = JwtHelper.GetJwtToken(
                                        model.UserName,
                                        _config.SigningKey,
                                        _config.Issuer,
                                        _config.Audience,
                                        TimeSpan.FromMinutes(_config.ExpiryTimeInMinutes),
                                        claims.ToArray());



                    result.Message = "User signed in successfully";
                    result.Success = true;


                }
                else
                {

                    result.Message = $"User sign in error : incorrect username or password";
                }
            }
            catch (Exception ex)
            {
                result.Message = $"Uenexpected error during user sign in ";
                result.Data = ex.Data;
            }

            return result;
        }



    }
}