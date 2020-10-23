using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.DispositivoRoot;

namespace Argos.Data.Types
{
    public class DispositivoMap : IEntityTypeConfiguration<Dispositivo>
    {
        public void Configure(EntityTypeBuilder<Dispositivo> builder)
        {
            builder.ToTable("dispositivos");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.Versao)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("versao");

            builder.Property(i => i.UsuarioId)
                .IsRequired()
                .HasColumnName("usuario_id");

            builder.HasOne(i => i.Usuario)
                .WithMany(i => i.Dispositivos);

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");
            

            builder.Property(i => i.Codigo)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("codigo_identificacao");

        }
    }
}