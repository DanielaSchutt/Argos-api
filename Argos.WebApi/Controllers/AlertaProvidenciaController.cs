using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.AlertaProvidenciaRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Argos.WebApi.Controllers
{
    [Route("api/alerta_providencia")]
    [ApiController]
    public class AlertaProvidenciaController : BaseController<AlertaProvidencia, AlertaProvidenciaViewModel>
    {
        private readonly IAlertaProvidenciaService Service;
        private readonly IMapper mapper;

        public AlertaProvidenciaController(
            IUnitOfWork unitOfWork,
            IAlertaProvidenciaService alertaProvidenciaService,
            IMapper mapper) : base(
                unitOfWork,
                alertaProvidenciaService,
                mapper
            )
        {
            this.Service = alertaProvidenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data =  await this.Service.GetAllAsync(include: i => i.Include(j => j.Alerta));
            return base.HttpMessageOk(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return await base._GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AlertaProvidencia item)
        {
            await this.Service.AddAsync(item);
            await _unitOfWork.Commit();
            return HttpMessageOk("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AlertaProvidencia item)
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