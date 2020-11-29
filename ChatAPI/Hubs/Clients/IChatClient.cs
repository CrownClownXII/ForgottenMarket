using System.Threading.Tasks;
using ChatAPI.Dtos;
using ChatAPI.Models;

namespace ChatAPI.Hubs.Clients
{
    public interface IChatClient
    {
         Task ReceiveMessage(MessageDto message);
         Task AddChatRoom(string roomName);
    }
}