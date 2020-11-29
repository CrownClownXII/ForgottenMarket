using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatAPI.DAL.Data;
using ChatAPI.Dtos;
using ChatAPI.Hubs.Clients;
using ChatAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using ChatAPI.Infrastructure;
using ChatAPI.Services;

namespace ChatAPI.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub<IChatClient>
    {
        private readonly ChatContext _context;
        public static Dictionary<Guid, string> _connectionsMapping = new Dictionary<Guid, string>();
        private readonly ILogger<ChatHub> _logger;
        private readonly IMapper _mapper;

        private readonly IRoomService _roomService;

        public ChatHub(ChatContext context, IMapper mapper, ILogger<ChatHub> logger, IRoomService roomService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _roomService = roomService;
        }

        public async override Task OnConnectedAsync()
        {
            var userExternalId = Context.GetLoggedUserExternalId();
            var user =  await _context.Users
                .FirstOrDefaultAsync(u => u.ExternalId == userExternalId);

            _logger.LogInformation($"Mapping connectionId to user with id : {user?.Id}");

            if(_connectionsMapping.ContainsKey(user.Id))
            {
                _logger.LogInformation($"Edited connections. User id : {user?.Id}, connectionId {Context.ConnectionId}");

                _connectionsMapping[user.Id] = Context.ConnectionId;
            }
            else 
            {
                _logger.LogInformation($"Added to connections. User id : {user?.Id}, connectionId {Context.ConnectionId}");

                _connectionsMapping.Add(user.Id, Context.ConnectionId);
            }

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(NewMessageDto message)
        {
            _logger.LogInformation($"Sending message to user: {message.ReceiverId} in room : {message.RoomId}");

            try
            {
                message.SenderExternalId = Context.GetLoggedUserExternalId();
                message.SenderLogin= Context.GetLoggedUserLogin();

                var result = await _roomService.SendMessageToUser(message);

                var connections = new List<string>
                {
                    Context.ConnectionId
                };

                if(_connectionsMapping.ContainsKey(message.ReceiverId))
                {
                    connections.Add(_connectionsMapping[message.ReceiverId]);
                }

            
                await Clients.Clients(connections).ReceiveMessage(result);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Error was thrown during sending messege. Exception message {e.Message}. Inner error message {e.InnerException?.Message}");
                throw e;
            }
        }
    }
}