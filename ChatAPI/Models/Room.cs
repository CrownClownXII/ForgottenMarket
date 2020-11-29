using System;
using System.Collections.Generic;

namespace ChatAPI.Models
{
    public class Room
    {
        public Room()
        {

            RoomUsers = new List<UserRoom>();

            Messeges = new List<Message>();
        }

        public Guid Id { get; set; }
        
        public List<UserRoom> RoomUsers { get; set; }

        public List<Message> Messeges { get; set; }
    }
}