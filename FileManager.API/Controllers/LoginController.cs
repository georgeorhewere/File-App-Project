using FileManager.Data;
using FileManager.Services.Implementations;
using FileManager.Services.Interfaces;
using FileManager.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJWTConfig _config;
        public LoginController(SignInManager<AppUser> signInManager, IJWTConfig config)
        {
            _signInManager = signInManager;
            _config = config;
        }


        [HttpPost]        
        public async Task<IActionResult> Post(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppLoginManager manager = new AppLoginManager(_signInManager,_config);
                var loginResult = await manager.LoginUser(model);
                return loginResult.Success ?  Ok(loginResult) : StatusCode(500,loginResult);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ExternalLogin(string provider, string returnUrl = null)
        //{
        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return Challenge(properties, provider);
        //}

        //[HttpGet]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        //{
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }

        //    var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        //    if (signInResult.Succeeded)
        //    {
        //        return RedirectToLocal(returnUrl);
        //    }
        //    if (signInResult.IsLockedOut)
        //    {
        //        return RedirectToAction(nameof(ForgotPassword));
        //    }
        //    else
        //    {
        //        ViewData["ReturnUrl"] = returnUrl;
        //        ViewData["Provider"] = info.LoginProvider;
        //        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        return View("ExternalLogin", new ExternalLoginModel { Email = email });
        //    }
        //}
    }
}
