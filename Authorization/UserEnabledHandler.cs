using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace TallerMVCWebApi.Authorization
{
    public class UserEnabledHandler : AuthorizationHandler<UserEnabled>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserEnabled userEnabled)
        {
            if (userEnabled.UserName == "admin@pica.com.co" && userEnabled.Password == "admin")
            {
                context.Succeed(userEnabled);
            }

            return Task.CompletedTask;
        }
    }
}