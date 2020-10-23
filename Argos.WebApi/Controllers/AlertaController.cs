using System.Threading.Tasks;
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
                predicate: i => i.Status == 1,
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(long id)
        {
            return await base._RemoveAsync(id);
        }
    }
}