using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.TipoAlertaRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlertaController : BaseController<TipoAlerta, TipoAlertaViewModel>
    {
        private readonly ITipoAlertaService Service;
        private readonly IMapper mapper;

        public TipoAlertaController(
            IUnitOfWork unitOfWork,
            ITipoAlertaService tipoAlertaService,
            IMapper mapper) : base(
                unitOfWork,
                tipoAlertaService,
                mapper
            )
        {
            this.Service = tipoAlertaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return await base._GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return await base._GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TipoAlerta item)
        {
            
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TipoAlerta item)
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