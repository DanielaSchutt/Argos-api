using Argos.Domain.CameraRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class CameraService : BaseService<Camera>, ICameraService
    {
        private readonly ICameraRepository CameraRepository;

        public CameraService(IUnitOfWork unitOfWork, ICameraRepository cameraRepository) : base(unitOfWork.CameraRepository)
        {
            this.CameraRepository = cameraRepository;
        }

        public override void Add(Camera obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Camera obj)
        {
            
            base.Update(obj);
        }
    }
}