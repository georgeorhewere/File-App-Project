﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Data.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            const string ADMINROLE = "Administrator";
            const string USERROLE = "User";
            // Seed App Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = ADMINROLE, NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Name = USERROLE, NormalizedName = "USER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // -----------------------------------------------------------------------------

            // Seed Users

            var passwordHasher = new PasswordHasher<AppUser>();
            List<AppUser> users = new List<AppUser>()
            {
                // imporant: don't forget NormalizedUserName, NormalizedEmail 
                 new AppUser {
                    UserName = "admin@filemanager.com",
                    NormalizedUserName = "ADMIN@FILEMANAGER.COM",
                    Email = "admin@filemanager.com",
                    NormalizedEmail = "ADMIN@FILEMANAGER.COM",
                },

                new AppUser {
                    UserName = "johndoe@filemanager.com",
                    NormalizedUserName = "JOHNDOE@FILEMANAGER.COM",
                    Email = "johndoe@filemanager.com",
                    NormalizedEmail = "JOHNDOE@FILEMANAGER.COM",
                },
            };
    


            builder.Entity<AppUser>().HasData(users);

            // Add Password For All Users
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "admin@Fileman17");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "johndoe@Fileman17");

            ///----------------------------------------------------
            // Seed UserRoles

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();         

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == ADMINROLE).Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId =
                roles.First(q => q.Name == USERROLE).Id
            });


            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }
    }


}
