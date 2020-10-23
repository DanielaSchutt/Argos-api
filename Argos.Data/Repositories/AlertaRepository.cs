using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.AlertaRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class AlertaRepository : BaseRepository<Alerta>,  IAlertaRepository
    {
        public AlertaRepository(DataContext context) : base(context) { }
    }
}