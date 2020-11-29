using IdentityServer.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.DAL.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Login)
                .HasColumnName("login")
                .HasMaxLength(50);

            builder.Property(c => c.PasswordHash)
                .HasColumnName("passwordhash");

            builder.Property(c => c.PasswordSalt)
                .HasColumnName("passwordsalt");
        }
    }
}