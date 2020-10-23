using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.AlertaRoot;

namespace Argos.Data.Types
{
    public class AlertaMap : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("alertas");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.CidadeId)
                .IsRequired()
                .HasColumnName("cidade_id");

            builder.HasOne(i => i.Cidade)
                .WithMany(i => i.Alertas);
            

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.TipoId)
                .IsRequired()
                .HasColumnName("tipo");

            builder.HasOne(i => i.Tipo)
                .WithMany(i => i.Alertas);

            builder.Property(i => i.Titulo)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("titulo");
            builder.Property(i => i.Status)
                .HasColumnName("status");

            builder.HasMany(i => i.Logs)
                .WithOne(i => i.Alerta);

            builder.Property(i => i.Placa)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("placa");

            builder.Property(i => i.Area)
                .HasMaxLength(500)
                .HasColumnName("area");

        }
    }
}