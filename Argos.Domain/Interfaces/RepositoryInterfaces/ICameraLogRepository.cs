using Argos.Domain.CameraLogRoot;

namespace Argos.Domain.Interfaces.RepositoryInterfaces
{
    public interface ICameraLogRepository : IBaseRepository<CameraLog>
    {
        CameraLog GetLastInserted(CameraLog item);
    }
}