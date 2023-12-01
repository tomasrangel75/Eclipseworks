using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Nome)
                .IsRequired();

            builder
                .Property(u => u.Sobrenome)
                .IsRequired();
        }
    
    }
}
