using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.AlertaProvidenciaRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class AlertaProvidenciaRepository : BaseRepository<AlertaProvidencia>,  IAlertaProvidenciaRepository
    {
        public AlertaProvidenciaRepository(DataContext context) : base(context) { }
    }
}