using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.TipoUsuarioRoot;

namespace Argos.Data.Types
{
    public class TipoUsuarioMap : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("tipo_usuario");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.HasMany(i => i.Usuarios)
                .WithOne(i => i.Tipo);

            builder.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("descricao");

        }
    }
}