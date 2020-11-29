using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.DAL.Model;

namespace IdentityServer.Services
{
    public interface IIdentityService
    {
        Task<User> FindByLogin(string login);
        string Authenticate(string password, byte[] hash, byte[] salt);
        Task<List<Claim>> GetClaimsForUser(long userId);
    }
}