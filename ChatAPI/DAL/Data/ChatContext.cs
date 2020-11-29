using ChatAPI.DAL.Data.Mappings;
using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.DAL.Data
{
    public class ChatContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> RoomUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public ChatContext(DbContextOptions<ChatContext> options) 
            : base(options)
        {
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new RoomUserMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}