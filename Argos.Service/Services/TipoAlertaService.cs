using Argos.Domain.TipoAlertaRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;

namespace Argos.Service
{
    public class TipoAlertaService : BaseService<TipoAlerta>, ITipoAlertaService
    {
        private readonly ITipoAlertaRepository TipoAlertaRepository;

        public TipoAlertaService(IUnitOfWork unitOfWork, ITipoAlertaRepository tipoAlertaRepository) : base(unitOfWork.TipoAlertaRepository)
        {
            this.TipoAlertaRepository = tipoAlertaRepository;
        }

        public override void Add(TipoAlerta obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(TipoAlerta obj)
        {
            
            base.Update(obj);
        }
    }
}