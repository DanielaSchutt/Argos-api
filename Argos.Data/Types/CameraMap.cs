using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Argos.Domain.CameraRoot;

namespace Argos.Data.Types
{
    public class CameraMap : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.ToTable("cameras");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

            builder.Property(i => i.Latitude)
                .IsRequired()
                .HasColumnName("latitude");

            builder.Property(i => i.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(i => i.Longitude)
                .IsRequired()
                .HasColumnName("longitude");

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("nome");

            builder.HasMany(i => i.Log)
                .WithOne(i => i.Camera);
            

            builder.Property(i => i.CriadoEm)
                .IsRequired()
                .HasColumnName("criado_em");

        }
    }
}