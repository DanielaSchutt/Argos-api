using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.TipoAlertaRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class TipoAlertaRepository : BaseRepository<TipoAlerta>,  ITipoAlertaRepository
    {
        public TipoAlertaRepository(DataContext context) : base(context) { }
    }
}