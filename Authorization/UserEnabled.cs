using Microsoft.AspNetCore.Authorization;

namespace TallerMVCWebApi.Authorization
{
    public class UserEnabled : IAuthorizationRequirement
    {
        public string UserName { get; }

        public string Password { get; }

        public UserEnabled()
        {
            UserName = "admin@pica.com.co";
            Password = "admin";
        }
    }
}