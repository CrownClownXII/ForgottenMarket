using System;

namespace ChatAPI.Dtos
{
    public class NewMessageDto
    {
        public Guid? RoomId { get; set; }
        public string Content { get; set; }
        public Guid ReceiverId { get; set; }
        public long SenderExternalId { get; set; }
        public string SenderLogin { get; set; }
    }
}