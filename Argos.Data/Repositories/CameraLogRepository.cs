using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Argos.Domain.CameraLogRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class CameraLogRepository : BaseRepository<CameraLog>,  ICameraLogRepository
    {
        public CameraLogRepository(DataContext context) : base(context) { }

        public CameraLog GetLastInserted(CameraLog item)
        {
            return DbSet.Where(i => i.AlertaId == item.AlertaId && i.CameraId == item.CameraId).OrderByDescending(i => i.CriadoEm).FirstOrDefault();
        }
    }
}