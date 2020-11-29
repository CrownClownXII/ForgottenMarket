using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Services;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;

namespace IdentityServer.Infrastructure
{
    public class ProfileService : IProfileService
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(IIdentityService identityService, ILogger<ProfileService> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.Claims.FirstOrDefault(c => c.Type == "sub");
            bool isParsed = long.TryParse(sub?.Value, out long userId);

            if(isParsed)
            {
                var claims = await _identityService.GetClaimsForUser(userId);
                context.IssuedClaims.AddRange(claims);   
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(true);
        }
    }
}