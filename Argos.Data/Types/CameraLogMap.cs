using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.CameraLogRoot;

namespace Argos.Data.Types
{
    public class CameraLogMap : IEntityTypeConfiguration<CameraLog>
    {
        public void Configure(EntityTypeBuilder<CameraLog> builder)
        {
            builder.ToTable("log_camera");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.AlertaId)
                .IsRequired()
                .HasColumnName("alerta_id");

            builder.HasOne(i => i.Alerta)
                .WithMany(i => i.Logs);

            builder.Property(i => i.CameraId)
                .IsRequired()
                .HasColumnName("camera_id");

            builder.HasOne(i => i.Camera)
                .WithMany(i => i.Log);

            builder.Property(i => i.Data)
                .IsRequired()
                .HasColumnName("data_deteccao");

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

        }
    }
}