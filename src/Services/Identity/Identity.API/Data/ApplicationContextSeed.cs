using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Identity.API.Data
{
    public class ApplicationContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public ApplicationContextSeed(IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task SeedAsync(IApplicationBuilder applicationBuilder, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;
            try
            {
                var context = (ApplicationDbContext)applicationBuilder
                    .ApplicationServices.GetService(typeof(ApplicationDbContext));

                context.Database.Migrate();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        GetDefaultUser());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;
                    var log = loggerFactory.CreateLogger("catalog seed");
                    log.LogError(ex.Message);
                    await SeedAsync(applicationBuilder, loggerFactory, retryForAvaiability);
                }
            }
        }

        private ApplicationUser GetDefaultUser()
        {
            var user = 
            new ApplicationUser()
            {
                CardHolderName = "s.krastanov",
                CardNumber = "4012888888881881",
                CardType = 1,
                City = "Plovdiv",
                Country = "Bulgaria",
                Email = "s.krastanov@s2kdesign.com",
                Expiration = "12/20",
                Id = Guid.NewGuid().ToString(), 
                LastName = "Krastanov", 
                Name = "Svetlin", 
                PhoneNumber = "1234567890", 
                UserName = "s.krastanov@s2kdesign.com", 
                ZipCode = "7000", 
                State = "WA", 
                Street = "15703 NE 61st Ct", 
                SecurityNumber = "535", 
                NormalizedEmail = "DEMOUSER@MICROSOFT.COM", 
                NormalizedUserName = "DEMOUSER@MICROSOFT.COM", 
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Pass@word1");

            return user;
        }
    }
}
