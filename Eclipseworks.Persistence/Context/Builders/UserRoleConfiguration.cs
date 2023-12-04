using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .ToTable("UserRoles");

            builder
             .HasOne<User>(u => u.User)
             .WithMany(ur => ur.UserRoles)
             .HasForeignKey(fk => fk.UserId);

            builder
             .HasOne<Role>(u => u.Role)
             .WithMany(ur => ur.UserRoles)
             .HasForeignKey(fk => fk.RoleId);
        }
    
    }
}
