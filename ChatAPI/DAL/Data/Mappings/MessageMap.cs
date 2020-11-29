using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatAPI.DAL.Data.Mappings
{
    public class MessageMap: IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("messages");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.RoomId)
                .HasColumnName("room_id");

            builder.Property(c => c.UserId)
                .HasColumnName("user_id");


            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(c => c.Content)
                .HasColumnName("content")
                .HasMaxLength(255);

            builder.HasOne(c => c.Room)
                .WithMany(r => r.Messeges)
                .HasForeignKey(c => c.RoomId);

            builder.HasOne(c => c.User)
                .WithMany(r => r.Messages)
                .HasForeignKey(c => c.UserId);
        }
    }
}