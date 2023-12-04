using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder
                    .ToTable("Roles");

                builder
                    .HasKey(r => r.Id);

                builder
                  .Property(r => r.Nome)
                  .IsRequired();

                builder
                    .Property(r => r.Descricao);
        }
    }
}
