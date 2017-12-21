using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> uM)
        {
            context.Database.EnsureCreated();

            //check for previous seedign or users
            if (context.Users.Any())
            {
                return;//no need to perform seeding operation
            }

            await CreateDefaultUsersForApplication(uM);
        }

        //method to create all necessary seeded users
        private static async Task CreateDefaultUsersForApplication(UserManager<ApplicationUser> uM)
        {
            string[] emails = new string[]{"Member1@email.com", "Customer1@email.com", "Customer2@email.com", "Customer3@email.com", "Customer4@email.com", "Customer5@email.com"};
            for (int i = 0; i < emails.Length; i++)
            {
                if (i == 0)
                {
                    var user = await CreateUser(uM, emails[i]);
                    await uM.AddClaimAsync(user, new Claim("member", "yes"));
                    await SetPasswordForUser(uM, emails[i], user);
                }
                else
                {
                    var user = await CreateUser(uM, emails[i]);
                    await uM.AddClaimAsync(user, new Claim("customer", "yes"));
                    await SetPasswordForUser(uM, emails[i], user);
                }
            }
        }

        //method for individual user creation
        private static async Task<ApplicationUser> CreateUser(UserManager<ApplicationUser> uM, string email)
        {
            var user = new ApplicationUser { UserName = email, Email = email};
            var createCheck = await uM.CreateAsync(user);
            if (!createCheck.Succeeded)
            {
                Console.WriteLine("*************************************************User creation failed for {1}", email);
            }
            var createdUser = await uM.FindByEmailAsync(email);
            return createdUser;
        }

        //method to set initial password for users
        private static async Task SetPasswordForUser(UserManager<ApplicationUser> uM, string email, ApplicationUser user)
        {
            const string password = "password";
            var passAssign = await uM.AddPasswordAsync(user, password);
            if (!passAssign.Succeeded)
            {
                Console.WriteLine("*************************************************Password add failed for {1}", email);
            }
        }
    }
}
