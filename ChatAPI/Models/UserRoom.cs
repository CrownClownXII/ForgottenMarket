using System;

namespace ChatAPI.Models
{
    public class UserRoom
    {
        public Guid Id { get; set; }
        
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}