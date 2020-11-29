using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatAPI.DAL.Data;
using ChatAPI.Dtos;
using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly ILogger<RoomService> _logger;
        private readonly IMapper _mapper;
        private readonly ChatContext _context;

        public RoomService(ILogger<RoomService> logger, IMapper mapper, ChatContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public Task<List<MessageDto>> GetMessagesForRoom(MessagesListFilters filters)
        {
            var messages = _context.Messages.Where(c => c.RoomId == filters.RoomId)
                .Include(c => c.User)
                .OrderByDescending(c => c.CreatedAt)
                .Take(filters.Amount)
                .Select(c => new MessageDto
                {
                    UserId = c.User.ExternalId,
                    Login = c.User.Login,
                    ChatRoomId = c.RoomId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .OrderBy(c => c.CreatedAt)
                .ToListAsync(); 

            return messages;
        }

        public async Task<List<RoomsDto>> GetRoomsForUser(long externlUserId)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.ExternalId == externlUserId); 

            var users = await _context.Users
                .Where(u => u.Id != user.Id)
                .ToListAsync();

            var userRooms = await _context.RoomUsers
                .Include(r => r.Room)
                .ThenInclude(r => r.RoomUsers)
                .Where(r => r.UserId == user.Id)
                .Select(r => r.Room)
                .SelectMany(r => r.RoomUsers)
                .ToListAsync();

            List<RoomsDto> result = new List<RoomsDto>();

            foreach(var item in users)
            {
                var userRoom = userRooms.FirstOrDefault(r => r.UserId == item.Id);

                result.Add(new RoomsDto
                {
                    RoomId = userRoom?.RoomId,
                    UserId = item.Id,
                    UserName = item.Login
                });
            }

             return result;
        }

        public async Task<MessageDto> SendMessageToUser(NewMessageDto message)
        {
            var room = await _context.Rooms
                .FirstOrDefaultAsync(c => c.Id == message.RoomId); 

            var sender =  await _context.Users
                .FirstOrDefaultAsync(u => u.ExternalId == message.SenderExternalId);
            
            var reciver =  await _context.Users
                .FirstOrDefaultAsync(u => u.Id == message.ReceiverId);

            if(room == null)
            {
                room = CreateRoom(sender, reciver);
            }

            var messageInDb = CreateMessage(message, sender, room);

            _context.SaveChanges();

            var result = _mapper.Map<Message, MessageDto>(messageInDb);
            result.UserId = sender.ExternalId;
            result.Login = message.SenderLogin;
            result.ChatRoomId = room.Id;

            return result;
        }

        private Room CreateRoom(User sender, User reciver)
        {
            var senderUserRoom = new UserRoom
            {
                User = sender
            };

            var reciverUserRoom = new UserRoom
            {
                User = reciver
            };

            var room = new Room
            {
                Id = Guid.NewGuid(),
                RoomUsers = new List<UserRoom>()
                {
                    senderUserRoom, 
                    reciverUserRoom
                }
            };

            _context.Rooms.Add(room);

            return room;
        }

        private Message CreateMessage(NewMessageDto message, User sender, Room room)
        {
            var messageInDb = _mapper.Map<NewMessageDto, Message>(message);

            messageInDb.CreatedAt = DateTime.Now;
            messageInDb.User = sender;
            messageInDb.Room = room;

            room.Messeges.Add(messageInDb);

            return messageInDb;
        }
    }
}