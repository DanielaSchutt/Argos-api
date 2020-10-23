using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.UsuarioRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService Service;
        private readonly IMapper mapper;

        public UsuarioController(
            IUnitOfWork unitOfWork,
            IUsuarioService usuarioService,
            IMapper mapper) : base(
                unitOfWork,
                usuarioService,
                mapper
            )
        {
            this.Service = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await this.Service.GetAllAsync(include: i => i.Include(j=> j.Tipo));
            return base.HttpMessageOk(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return await base._GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Usuario item)
        {
            this.Service.Add(item);
            await _unitOfWork.Commit();
            return base.HttpMessageOk("success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Usuario item)
        {
            this.Service.Update(item);
            await _unitOfWork.Commit();
            return base.HttpMessageOk("success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(long id)
        {
            return await base._RemoveAsync(id);
        }
    }
}