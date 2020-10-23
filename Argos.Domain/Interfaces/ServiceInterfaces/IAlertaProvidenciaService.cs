using System.Threading.Tasks;
using Argos.Domain.AlertaProvidenciaRoot;

namespace Argos.Domain.Interfaces.ServiceInterfaces
{
    public interface IAlertaProvidenciaService : IBaseService<AlertaProvidencia>
    {
        Task AddAsync(AlertaProvidencia obj);
    }
}