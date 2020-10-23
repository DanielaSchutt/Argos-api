using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.UsuarioPosicaoRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPosicaoController : BaseController<UsuarioPosicao, UsuarioPosicaoViewModel>
    {
        private readonly IUsuarioPosicaoService Service;
        private readonly IMapper mapper;

        public UsuarioPosicaoController(
            IUnitOfWork unitOfWork,
            IUsuarioPosicaoService usuarioPosicaoService,
            IMapper mapper) : base(
                unitOfWork,
                usuarioPosicaoService,
                mapper
            )
        {
            this.Service = usuarioPosicaoService;
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
        public async Task<IActionResult> AddAsync(UsuarioPosicao item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UsuarioPosicao item)
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