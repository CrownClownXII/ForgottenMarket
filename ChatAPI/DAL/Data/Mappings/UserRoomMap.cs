using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatAPI.DAL.Data.Mappings
{
    public class RoomUserMap : IEntityTypeConfiguration<UserRoom>
    {
        public void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.ToTable("user_rooms");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.RoomId)
                .HasColumnName("room_id");

            builder.Property(c => c.UserId)
                .HasColumnName("user_id");

            builder.HasOne(c => c.Room)
                .WithMany(r => r.RoomUsers)
                .HasForeignKey(r => r.RoomId);

            builder.HasOne(c => c.User)
                .WithMany(r => r.UserRooms)
                .HasForeignKey(r => r.UserId);
        }
    }
}