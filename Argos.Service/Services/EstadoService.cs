using Argos.Domain.EstadoRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository EstadoRepository;

        public EstadoService(IUnitOfWork unitOfWork, IEstadoRepository estadoRepository) : base(unitOfWork.EstadoRepository)
        {
            this.EstadoRepository = estadoRepository;
        }

        public override void Add(Estado obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Estado obj)
        {
            
            base.Update(obj);
        }
    }
}