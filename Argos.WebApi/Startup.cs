using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System;
using System.Text;
using dotenv.net.DependencyInjection.Extensions;
using Argos.Data.Context;
using Argos.Data.Repositories;
using Argos.Service;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
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
using Argos.Domain.BaseRoot;
using Microsoft.IdentityModel.Logging;


namespace Argos.WebApi.Controllers
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Info
                {
                    Title = "automapi",
                    Version = "v1"
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("fiver",policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddMvc()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            if (File.Exists(".env.local"))
            {
                services.AddEnv(builder =>
                {
                    builder
                    .AddEnvFile(".env.local")
                    .AddThrowOnError(false)
                    .AddEncoding(Encoding.UTF8);
                });
            }
            else
            {
                throw new Exception("Eu venho do futuro dizer que você não incluiu o arquivo .env no servidor :( - ");
            }

            var connectionString = Environment.GetEnvironmentVariable(Constants.CONNECTION_STRING);
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioPosicaoRepository, UsuarioPosicaoRepository>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IDispositivoRepository, DispositivoRepository>();
            services.AddScoped<ICameraRepository, CameraRepository>();
            services.AddScoped<ICameraLogRepository, CameraLogRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IAlertaRepository, AlertaRepository>();
            services.AddScoped<ITipoAlertaRepository, TipoAlertaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IAlertaProvidenciaRepository, AlertaProvidenciaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioPosicaoService, UsuarioPosicaoService>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<IDispositivoService, DispositivoService>();
            services.AddScoped<ICameraService, CameraService>();
            services.AddScoped<ICameraLogService, CameraLogService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IAlertaService, AlertaService>();
            services.AddScoped<ITipoAlertaService, TipoAlertaService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IAlertaProvidenciaService, AlertaProvidenciaService>();


            services.AddScoped<IValidator<Usuario>, UsuarioValidator>();
            services.AddScoped<IValidator<UsuarioPosicao>, UsuarioPosicaoValidator>();
            services.AddScoped<IValidator<TipoUsuario>, TipoUsuarioValidator>();
            services.AddScoped<IValidator<Dispositivo>, DispositivoValidator>();
            services.AddScoped<IValidator<Camera>, CameraValidator>();
            services.AddScoped<IValidator<CameraLog>, CameraLogValidator>();
            services.AddScoped<IValidator<Cidade>, CidadeValidator>();
            services.AddScoped<IValidator<Alerta>, AlertaValidator>();
            services.AddScoped<IValidator<TipoAlerta>, TipoAlertaValidator>();
            services.AddScoped<IValidator<Estado>, EstadoValidator>();
            services.AddScoped<IValidator<AlertaProvidencia>, AlertaProvidenciaValidator>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseAuthentication();
            app.UseCors("fiver");
            app.UseMvc();
           
            // var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            // optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            // var db = new DataContext(optionsBuilder.Options);
            // var TotalMigrations = db.Database.GetMigrations();
            // var AppliedMigrations = db.Database.GetAppliedMigrations();
            // if (AppliedMigrations.Count() < TotalMigrations.Count())
            // {
            // db.Database.Migrate();
            // }
        }
    }
}
