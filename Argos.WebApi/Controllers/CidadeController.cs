using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.CidadeRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : BaseController<Cidade, CidadeViewModel>
    {
        private readonly ICidadeService Service;
        private readonly IMapper mapper;

        public CidadeController(
            IUnitOfWork unitOfWork,
            ICidadeService cidadeService,
            IMapper mapper) : base(
                unitOfWork,
                cidadeService,
                mapper
            )
        {
            this.Service = cidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var data =  await this.Service.GetAllAsync(include: i => i.Include(j => j.Estado));
            return base.HttpMessageOk(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return await base._GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Cidade item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Cidade item)
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