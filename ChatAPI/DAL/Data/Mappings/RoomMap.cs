using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatAPI.DAL.Data.Mappings
{
    public class RoomMap: IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("rooms");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.HasMany(r => r.RoomUsers)
                .WithOne(u => u.Room)
                .HasForeignKey(r => r.RoomId);

            builder.HasMany(r => r.Messeges)
                .WithOne(u => u.Room)
                .HasForeignKey(r => r.RoomId);
        }
    }
}