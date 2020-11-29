using System.Threading.Tasks;
using ChatAPI.Models;

namespace ChatAPI.Services
{
    public class UserService : IUserService
    {
        public Task<User> FindUserByExternalId(long externalId)
        {
            throw new System.NotImplementedException();
        }
    }
}