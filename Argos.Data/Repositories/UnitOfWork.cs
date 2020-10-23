using System.Threading.Tasks;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private IUsuarioRepository _UsuarioRepository;
        private IUsuarioPosicaoRepository _UsuarioPosicaoRepository;
        private ITipoUsuarioRepository _TipoUsuarioRepository;
        private IDispositivoRepository _DispositivoRepository;
        private ICameraRepository _CameraRepository;
        private ICameraLogRepository _CameraLogRepository;
        private ICidadeRepository _CidadeRepository;
        private IAlertaRepository _AlertaRepository;
        private ITipoAlertaRepository _TipoAlertaRepository;
        private IEstadoRepository _EstadoRepository;
        private IAlertaProvidenciaRepository _AlertaProvidenciaRepository;
        
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }



        public IUsuarioRepository UsuarioRepository
        {
            get { return _UsuarioRepository = _UsuarioRepository ?? new UsuarioRepository(_context); }
        }

        public IUsuarioPosicaoRepository UsuarioPosicaoRepository
        {
            get { return _UsuarioPosicaoRepository = _UsuarioPosicaoRepository ?? new UsuarioPosicaoRepository(_context); }
        }

        public ITipoUsuarioRepository TipoUsuarioRepository
        {
            get { return _TipoUsuarioRepository = _TipoUsuarioRepository ?? new TipoUsuarioRepository(_context); }
        }

        public IDispositivoRepository DispositivoRepository
        {
            get { return _DispositivoRepository = _DispositivoRepository ?? new DispositivoRepository(_context); }
        }

        public ICameraRepository CameraRepository
        {
            get { return _CameraRepository = _CameraRepository ?? new CameraRepository(_context); }
        }

        public ICameraLogRepository CameraLogRepository
        {
            get { return _CameraLogRepository = _CameraLogRepository ?? new CameraLogRepository(_context); }
        }

        public ICidadeRepository CidadeRepository
        {
            get { return _CidadeRepository = _CidadeRepository ?? new CidadeRepository(_context); }
        }

        public IAlertaRepository AlertaRepository
        {
            get { return _AlertaRepository = _AlertaRepository ?? new AlertaRepository(_context); }
        }

        public ITipoAlertaRepository TipoAlertaRepository
        {
            get { return _TipoAlertaRepository = _TipoAlertaRepository ?? new TipoAlertaRepository(_context); }
        }

        public IEstadoRepository EstadoRepository
        {
            get { return _EstadoRepository = _EstadoRepository ?? new EstadoRepository(_context); }
        }

        public IAlertaProvidenciaRepository AlertaProvidenciaRepository
        {
            get { return _AlertaProvidenciaRepository = _AlertaProvidenciaRepository ?? new AlertaProvidenciaRepository(_context); }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}