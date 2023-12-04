using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder
                .ToTable("Projetos");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .IsRequired();

            builder
                .Property(p => p.Status)
                .IsRequired();
        }
    
    }
}
