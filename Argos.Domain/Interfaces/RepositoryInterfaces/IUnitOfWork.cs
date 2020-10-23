using System.Threading.Tasks;

namespace Argos.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork
    {

        IUsuarioRepository UsuarioRepository { get; }
        IUsuarioPosicaoRepository UsuarioPosicaoRepository { get; }
        ITipoUsuarioRepository TipoUsuarioRepository { get; }
        IDispositivoRepository DispositivoRepository { get; }
        ICameraRepository CameraRepository { get; }
        ICameraLogRepository CameraLogRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        IAlertaRepository AlertaRepository { get; }
        ITipoAlertaRepository TipoAlertaRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IAlertaProvidenciaRepository AlertaProvidenciaRepository { get; }
        Task Commit();
    }
}