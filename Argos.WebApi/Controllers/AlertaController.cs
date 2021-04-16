using System.Threading.Tasks;
using Argos.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.AlertaRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : BaseController<Alerta, AlertaViewModel>
    {
        private readonly IAlertaService Service;
        private readonly IMapper mapper;

        public AlertaController(
            IUnitOfWork unitOfWork,
            IAlertaService alertaService,
            IMapper mapper) : base(
                unitOfWork,
                alertaService,
                mapper
            )
        {
            this.Service = alertaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data =  await this.Service.GetAllAsync(include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            return base.HttpMessageOk(data);
        }
        [HttpGet("abertos")]
        public async Task<IActionResult> GetAllOpenAsync()
        {
            var data =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 0);
            return base.HttpMessageOk(data);
        }
        [HttpGet("counter")]
        public async Task<IActionResult> GetAllCounterAsync()
        {
            var abertos =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 0,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            var fechados =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 2,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            
            return base.HttpMessageOk(new {
                counters = new
                {
                    aberto = abertos.Count,
                    fechado = fechados.Count
                }
            });
        }
        
        [HttpGet("abertosCidade")]
        public async Task<IActionResult> GetAllOpenByLocationAsync()
        {
            var data =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 0,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            return base.HttpMessageOk(data);
        }
        [HttpGet("fechadosCidade")]
        public async Task<IActionResult> GetAllOpenByCidadeAsync()
        {
            var data =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 2,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            return base.HttpMessageOk(data);
        }
        
        [HttpGet("abertosUsuario")]
        public async Task<IActionResult> GetAllOpenByUserAsync()
        {
            var user = TokenGenerator.GetId(this.GetTokenDefault());
            var data =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 1 && i.UsuarioId == user,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            return base.HttpMessageOk(data);
        }
        
        [HttpGet("fechadosUsuario")]
        public async Task<IActionResult> GetAllClosedByUserAsync()
        {
            var user = TokenGenerator.GetId(this.GetTokenDefault());
            var data =  await this.Service.GetAllAsync(
                predicate: i => i.Status == 2 && i.UsuarioId == user,
                include: i => i.Include(j => j.Tipo).Include(j => j.Cidade));
            return base.HttpMessageOk(data);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return await base._GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Alerta item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Alerta item)
        {
            return await base._UpdateAsync(id, item);
        }
        
        [HttpPut("{id}/alocar")]
        public async Task<IActionResult> UpdateLocateAsync(long id)
        {
            var item = await this.Service.GetByIdAsync(id);
            if(item.Status != 1){
                item.Status = 1;
                item.UsuarioId = TokenGenerator.GetId(this.GetTokenDefault());
                return await base._UpdateAsync(id, item);
            }
            else
            {
                return base.BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(long id)
        {
            return await base._RemoveAsync(id);
        }
    }
}