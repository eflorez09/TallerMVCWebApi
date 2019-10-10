using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TallerMVCWebApi.Authorization
{
    public class AppIdentityDbContextSeed
    {
        public static void SeedAsync(UserManager<IdentityUser> userManager)
        {
            IdentityUser identityUser = new IdentityUser
            {
                UserName = "admin@pica.com",
                Email = "admin@pica.com"
            };

            Task.Run(async () =>
            {
                await userManager.CreateAsync(identityUser, "admin");
            }).Wait();
        }
    }
}