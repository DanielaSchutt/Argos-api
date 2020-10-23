using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.CameraLogRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraLogController : BaseController<CameraLog, CameraLogViewModel>
    {
        private readonly ICameraLogService Service;
        private readonly IMapper mapper;

        public CameraLogController(
            IUnitOfWork unitOfWork,
            ICameraLogService cameraLogService,
            IMapper mapper) : base(
                unitOfWork,
                cameraLogService,
                mapper
            )
        {
            this.Service = cameraLogService;
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
        public async Task<IActionResult> AddAsync(CameraLog item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CameraLog item)
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