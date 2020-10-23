using Argos.Domain.UsuarioPosicaoRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class UsuarioPosicaoService : BaseService<UsuarioPosicao>, IUsuarioPosicaoService
    {
        private readonly IUsuarioPosicaoRepository UsuarioPosicaoRepository;

        public UsuarioPosicaoService(IUnitOfWork unitOfWork, IUsuarioPosicaoRepository usuarioPosicaoRepository) : base(unitOfWork.UsuarioPosicaoRepository)
        {
            this.UsuarioPosicaoRepository = usuarioPosicaoRepository;
        }

        public override void Add(UsuarioPosicao obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(UsuarioPosicao obj)
        {
            
            base.Update(obj);
        }
    }
}