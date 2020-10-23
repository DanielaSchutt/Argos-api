using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.DispositivoRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : BaseController<Dispositivo, DispositivoViewModel>
    {
        private readonly IDispositivoService Service;
        private readonly IMapper mapper;

        public DispositivoController(
            IUnitOfWork unitOfWork,
            IDispositivoService dispositivoService,
            IMapper mapper) : base(
                unitOfWork,
                dispositivoService,
                mapper
            )
        {
            this.Service = dispositivoService;
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
        public async Task<IActionResult> AddAsync(Dispositivo item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Dispositivo item)
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