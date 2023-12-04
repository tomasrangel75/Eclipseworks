using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder
                .ToTable("Tarefas");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Titulo)
                .IsRequired();
            
            builder
              .Property(t => t.Descricao)
              .IsRequired();

            builder
             .Property(t => t.DataVencimento)
             .IsRequired();

            builder
             .Property(t => t.Status)
             .IsRequired();

            builder
             .Property(t => t.DataVencimento)
             .IsRequired();

            builder
             .Property(t => t.Status)
             .IsRequired();

            builder
            .Property(t => t.Prioridade)
            .IsRequired();

            builder
               .HasOne<Projeto>(t => t.Projeto)
               .WithMany(ts => ts.Tarefas)
               .HasForeignKey(fk => fk.ProjetoId);
        }
    
    }
}
