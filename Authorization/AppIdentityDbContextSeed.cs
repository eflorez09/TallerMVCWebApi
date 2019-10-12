using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TallerMVCWebApi.Authorization
{
    public class AppIdentityDbContextSeed
    {
        public static void SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = "admin@pica.com",
                Email = "admin@pica.com"
            };

            Task.Run(async () =>
            {
                await userManager.CreateAsync(applicationUser, "admin");
            }).Wait();
        }
    }
}