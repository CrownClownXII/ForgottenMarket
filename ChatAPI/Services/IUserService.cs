using System.Threading.Tasks;
using ChatAPI.Models;

namespace ChatAPI.Services
{
    public interface IUserService
    {
         Task<User> FindUserByExternalId(long externalId);
    }
}