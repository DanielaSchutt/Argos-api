using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.EstadoRoot;

namespace Argos.Data.Types
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estados");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nome");

            builder.HasMany(i => i.Cidades)
                .WithOne(i => i.Estado);

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

        }
    }
}