using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.EstadoRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class EstadoRepository : BaseRepository<Estado>,  IEstadoRepository
    {
        public EstadoRepository(DataContext context) : base(context) { }
    }
}