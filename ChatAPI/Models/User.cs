using System;
using System.Collections.Generic;

namespace ChatAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public long ExternalId { get; set; }
        public List<Message> Messages { get; set; }
        public List<UserRoom> UserRooms { get; set; }
    }
}