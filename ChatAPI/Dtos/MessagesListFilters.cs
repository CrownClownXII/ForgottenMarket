using System;

namespace ChatAPI.Dtos
{
    public class MessagesListFilters
    {
        public MessagesListFilters()
        {
            Amount = 10;
        }

        public int Amount { get; set; }
        public Guid RoomId { get; set; }
    }
}