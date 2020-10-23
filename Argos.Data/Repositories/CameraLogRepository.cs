using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.CameraLogRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class CameraLogRepository : BaseRepository<CameraLog>,  ICameraLogRepository
    {
        public CameraLogRepository(DataContext context) : base(context) { }
    }
}