using Argos.Domain.DispositivoRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class DispositivoService : BaseService<Dispositivo>, IDispositivoService
    {
        private readonly IDispositivoRepository DispositivoRepository;

        public DispositivoService(IUnitOfWork unitOfWork, IDispositivoRepository dispositivoRepository) : base(unitOfWork.DispositivoRepository)
        {
            this.DispositivoRepository = dispositivoRepository;
        }

        public override void Add(Dispositivo obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Dispositivo obj)
        {
            
            base.Update(obj);
        }
    }
}