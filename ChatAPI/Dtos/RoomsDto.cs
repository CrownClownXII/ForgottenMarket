using System;

namespace ChatAPI.Dtos
{
    public class RoomsDto
    {
        public Guid? RoomId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}