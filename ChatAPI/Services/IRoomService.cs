using System.Collections.Generic;
using System.Threading.Tasks;
using ChatAPI.Dtos;

namespace ChatAPI.Services
{
    public interface IRoomService
    {
        Task<List<MessageDto>> GetMessagesForRoom(MessagesListFilters filters);
        Task<List<RoomsDto>> GetRoomsForUser(long externlUserId);
        Task<MessageDto> SendMessageToUser(NewMessageDto message);       
    }
}