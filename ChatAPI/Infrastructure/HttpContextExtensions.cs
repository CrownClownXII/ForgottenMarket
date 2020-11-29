using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace ChatAPI.Infrastructure
{
    public static class HttpContextExtensions
    {
        public static long GetLoggedUserExternalId(this HttpContext context)
        {
            var senderId = context.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            bool isParsed = long.TryParse(senderId, out long parsedId);

            if(!isParsed)
            {
                throw new System.Exception("There is no id in user claims");
            }

            return parsedId;
        }
    }

    public static class HubCallerContextExtensions
    {
        public static long GetLoggedUserExternalId(this HubCallerContext context)
        {
            var senderId = context.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            bool isParsed = long.TryParse(senderId, out long parsedId);

            if(!isParsed)
            {
                throw new System.Exception("There is no id in user claims");
            }

            return parsedId;
        }

        public static string GetLoggedUserLogin(this HubCallerContext context)
        {
            var login = context.User.Claims.FirstOrDefault(c => c.Type == "login")?.Value;

            return login;
        }
    }
}