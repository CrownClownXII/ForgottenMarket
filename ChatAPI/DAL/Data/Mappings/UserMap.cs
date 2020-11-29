using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatAPI.DAL.Data.Mappings
{
    public class UserMap: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Login)
                .HasColumnName("login");

            builder.Property(c => c.ExternalId)
                .HasColumnName("external_id");

            builder.HasMany(c => c.Messages)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.UserRooms)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}