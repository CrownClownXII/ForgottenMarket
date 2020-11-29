using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatAPI.Dtos;
using ChatAPI.Infrastructure;
using ChatAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ChatAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ChatController: ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IRoomService _roomService;

        public ChatController(ILogger<ChatController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [HttpGet("message/lastest")]
        public async Task<ActionResult> Get([FromQuery]MessagesListFilters filters)
        {
            _logger.LogInformation($"Retriving last {filters.Amount} messages for room {filters.RoomId.ToString()}");

            List<MessageDto> messages = new List<MessageDto>();

            try 
            {
                messages = await _roomService.GetMessagesForRoom(filters);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Error was thrown during retriving messeges. Exception message {e.Message}. Inner error message {e.InnerException?.Message}");
                throw e;
            }

            return Ok(messages);
        }

        [HttpGet("rooms")]
        public async Task<ActionResult> GetRooms()
        {          
            var userExternalId = HttpContext.GetLoggedUserExternalId();

            _logger.LogInformation($"Retriving rooms for user {userExternalId}");

            List<RoomsDto> result = new List<RoomsDto>();

            try 
            {
                result = await _roomService.GetRoomsForUser(userExternalId);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Error was thrown during retriving rooms. Exception message {e.Message}. Inner error message {e.InnerException?.Message}");
                throw e;
            }

            return Ok(result);
        }
    }
}