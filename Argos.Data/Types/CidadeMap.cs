using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.CidadeRoot;

namespace Argos.Data.Types
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidades");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nome");

            builder.HasMany(i => i.Alertas)
                .WithOne(i => i.Cidade);

            builder.Property(i => i.EstadoId)
                .IsRequired()
                .HasColumnName("estado_id");

            builder.HasOne(i => i.Estado)
                .WithMany(i => i.Cidades);
            

        }
    }
}