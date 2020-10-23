using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.DispositivoRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class DispositivoRepository : BaseRepository<Dispositivo>,  IDispositivoRepository
    {
        public DispositivoRepository(DataContext context) : base(context) { }
    }
}