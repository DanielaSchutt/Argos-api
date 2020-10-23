using Argos.Domain.TipoUsuarioRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class TipoUsuarioService : BaseService<TipoUsuario>, ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository TipoUsuarioRepository;

        public TipoUsuarioService(IUnitOfWork unitOfWork, ITipoUsuarioRepository tipoUsuarioRepository) : base(unitOfWork.TipoUsuarioRepository)
        {
            this.TipoUsuarioRepository = tipoUsuarioRepository;
        }

        public override void Add(TipoUsuario obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(TipoUsuario obj)
        {
            
            base.Update(obj);
        }
    }
}