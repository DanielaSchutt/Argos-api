using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.EstadoRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : BaseController<Estado, EstadoViewModel>
    {
        private readonly IEstadoService Service;
        private readonly IMapper mapper;

        public EstadoController(
            IUnitOfWork unitOfWork,
            IEstadoService estadoService,
            IMapper mapper) : base(
                unitOfWork,
                estadoService,
                mapper
            )
        {
            this.Service = estadoService;
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
        public async Task<IActionResult> AddAsync(Estado item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Estado item)
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