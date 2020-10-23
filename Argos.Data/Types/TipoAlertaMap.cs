using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.TipoAlertaRoot;

namespace Argos.Data.Types
{
    public class TipoAlertaMap : IEntityTypeConfiguration<TipoAlerta>
    {
        public void Configure(EntityTypeBuilder<TipoAlerta> builder)
        {
            builder.ToTable("tipos_alerta");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("descricao");

            builder.HasMany(i => i.Alertas)
                .WithOne(i => i.Tipo);

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");



        }
    }
}