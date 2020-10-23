using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.UsuarioPosicaoRoot;

namespace Argos.Data.Types
{
    public class UsuarioPosicaoMap : IEntityTypeConfiguration<UsuarioPosicao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPosicao> builder)
        {
            builder.ToTable("usuario_posicao");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.UsuarioId)
                .IsRequired()
                .HasColumnName("usuario_id");

            builder.HasOne(i => i.Usuario)
                .WithOne()
                .HasForeignKey<UsuarioPosicao>(i => i.UsuarioId);

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.Longitude)
                .IsRequired()
                .HasColumnName("longitude");

            builder.Property(i => i.Latitude)
                .IsRequired()
                .HasColumnName("latitude");

        }
    }
}