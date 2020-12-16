using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.UsuarioRoot;

namespace Argos.Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(i => i.Cpf)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("cpf");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.HasMany(i => i.Posicoes)
                .WithOne(i => i.Usuario);

            builder.Property(i => i.TipoId)
                .IsRequired()
                .HasColumnName("tipo_id");

            builder.HasOne(i => i.Tipo)
                .WithMany(i => i.Usuarios);

            builder.Property(i => i.Matricula)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("matricula");

            builder.HasMany(i => i.Dispositivos)
                .WithOne(i => i.Usuario);

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");
            builder.Property(i => i.TokenFirebase)
                .HasMaxLength(300)
                .HasColumnName("token_firebase");
            builder.Property(i => i.IsRevoked)
                .HasColumnName("is_revoked");

/**            builder.Property(i => i.Senha)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("senha");*/

            builder.Property(i => i.PasswordHash)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("password_hash");

        }
    }
}