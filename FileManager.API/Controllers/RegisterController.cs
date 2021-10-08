﻿using FileManager.Data;
using FileManager.Services.Implementations;
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
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        public RegisterController(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
        }
        // POST api/register
        [HttpPost]
        public async Task<IActionResult> Post(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUserManager manager = new AppUserManager(userManager);
                var result = await manager.CreateUser(model);
                if (result.Success)
                    return Ok(model);
                else
                    return StatusCode(500, result.Message);
            }
            else
            {                
                return BadRequest(ModelState);
            }

            
        }



    }
}
