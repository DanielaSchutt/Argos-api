using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.TipoUsuarioRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : BaseController<TipoUsuario, TipoUsuarioViewModel>
    {
        private readonly ITipoUsuarioService Service;
        private readonly IMapper mapper;

        public TipoUsuarioController(
            IUnitOfWork unitOfWork,
            ITipoUsuarioService tipoUsuarioService,
            IMapper mapper) : base(
                unitOfWork,
                tipoUsuarioService,
                mapper
            )
        {
            this.Service = tipoUsuarioService;
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
        public async Task<IActionResult> AddAsync(TipoUsuario item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TipoUsuario item)
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