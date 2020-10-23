using Microsoft.EntityFrameworkCore;
using Argos.Domain.UsuarioRoot;
using Argos.Domain.UsuarioPosicaoRoot;
using Argos.Domain.TipoUsuarioRoot;
using Argos.Domain.DispositivoRoot;
using Argos.Domain.CameraRoot;
using Argos.Domain.CameraLogRoot;
using Argos.Domain.CidadeRoot;
using Argos.Domain.AlertaRoot;
using Argos.Domain.TipoAlertaRoot;
using Argos.Domain.EstadoRoot;
using Argos.Domain.AlertaProvidenciaRoot;
using Argos.Data.Types;

namespace Argos.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { /**Database.EnsureCreated();*/}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioPosicaoMap());
            modelBuilder.ApplyConfiguration(new TipoUsuarioMap());
            modelBuilder.ApplyConfiguration(new DispositivoMap());
            modelBuilder.ApplyConfiguration(new CameraMap());
            modelBuilder.ApplyConfiguration(new CameraLogMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new AlertaMap());
            modelBuilder.ApplyConfiguration(new TipoAlertaMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new AlertaProvidenciaMap());

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Usuario> DbSetUsuario { get; set; }
        public DbSet<UsuarioPosicao> DbSetUsuarioPosicao { get; set; }
        public DbSet<TipoUsuario> DbSetTipoUsuario { get; set; }
        public DbSet<Dispositivo> DbSetDispositivo { get; set; }
        public DbSet<Camera> DbSetCamera { get; set; }
        public DbSet<CameraLog> DbSetCameraLog { get; set; }
        public DbSet<Cidade> DbSetCidade { get; set; }
        public DbSet<Alerta> DbSetAlerta { get; set; }
        public DbSet<TipoAlerta> DbSetTipoAlerta { get; set; }
        public DbSet<Estado> DbSetEstado { get; set; }
        public DbSet<AlertaProvidencia> DbSetAlertaProvidencia { get; set; }

    }
}