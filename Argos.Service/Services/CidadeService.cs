using Argos.Domain.CidadeRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository CidadeRepository;

        public CidadeService(IUnitOfWork unitOfWork, ICidadeRepository cidadeRepository) : base(unitOfWork.CidadeRepository)
        {
            this.CidadeRepository = cidadeRepository;
        }

        public override void Add(Cidade obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Cidade obj)
        {
            
            base.Update(obj);
        }
    }
}