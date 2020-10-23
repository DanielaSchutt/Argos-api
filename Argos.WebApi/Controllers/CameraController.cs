using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.CameraRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : BaseController<Camera, CameraViewModel>
    {
        private readonly ICameraService Service;
        private readonly IMapper mapper;

        public CameraController(
            IUnitOfWork unitOfWork,
            ICameraService cameraService,
            IMapper mapper) : base(
                unitOfWork,
                cameraService,
                mapper
            )
        {
            this.Service = cameraService;
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
        public async Task<IActionResult> AddAsync(Camera item)
        {
            return await base._AddAsync(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] Camera item)
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