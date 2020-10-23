using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.CameraRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class CameraRepository : BaseRepository<Camera>,  ICameraRepository
    {
        public CameraRepository(DataContext context) : base(context) { }
    }
}