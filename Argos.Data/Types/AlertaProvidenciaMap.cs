using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.AlertaProvidenciaRoot;

namespace Argos.Data.Types
{
    public class AlertaProvidenciaMap : IEntityTypeConfiguration<AlertaProvidencia>
    {
        public void Configure(EntityTypeBuilder<AlertaProvidencia> builder)
        {
            builder.ToTable("alerta_providencia");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("descricao");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");
            

            builder.Property(i => i.AlertaId)
                .IsRequired()
                .HasColumnName("alerta_id");

            builder.HasOne(i => i.Alerta)
                .WithOne()
                .HasForeignKey<AlertaProvidencia>(i => i.AlertaId);

        }
    }
}