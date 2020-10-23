using Argos.Domain.CameraLogRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class CameraLogService : BaseService<CameraLog>, ICameraLogService
    {
        private readonly ICameraLogRepository CameraLogRepository;

        public CameraLogService(IUnitOfWork unitOfWork, ICameraLogRepository cameraLogRepository) : base(unitOfWork.CameraLogRepository)
        {
            this.CameraLogRepository = cameraLogRepository;
        }

        public override void Add(CameraLog obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(CameraLog obj)
        {
            
            base.Update(obj);
        }
    }
}