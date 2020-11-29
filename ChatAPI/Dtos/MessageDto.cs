using System;

namespace ChatAPI.Dtos
{
    public class MessageDto
    {
        public Guid ChatRoomId { get; set; }
        public long UserId { get; set; }
        public string Login { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}