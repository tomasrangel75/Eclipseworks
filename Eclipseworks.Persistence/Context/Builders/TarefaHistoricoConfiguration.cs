using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Persistence.Context.Builders
{
    public class TarefaHistoricoConfiguration : IEntityTypeConfiguration<TarefaHistorico>
    {
        public void Configure(EntityTypeBuilder<TarefaHistorico> builder)
        {
            builder
                .ToTable("TarefaHistoricos");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.ColunaModificada)
                .IsRequired();
           
            builder
                .Property(t => t.TipoModificacao)
                .IsRequired();

            builder
                .Property(t => t.ValorAtual)
                .IsRequired();

            builder
             .HasOne<Tarefa>(t => t.Tarefa)
             .WithMany(ts => ts.TarefaHistoricos)
             .HasForeignKey(fk => fk.TarefaId);
        }
    
    }
}
