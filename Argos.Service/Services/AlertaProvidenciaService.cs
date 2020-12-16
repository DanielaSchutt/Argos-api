using Argos.Domain.AlertaProvidenciaRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Argos.Service
{
    public class AlertaProvidenciaService : BaseService<AlertaProvidencia>, IAlertaProvidenciaService
    {
        private readonly IAlertaProvidenciaRepository AlertaProvidenciaRepository;
        private readonly IAlertaRepository AlertaRepository;
        public AlertaProvidenciaService(IUnitOfWork unitOfWork, IAlertaProvidenciaRepository alertaProvidenciaRepository, IAlertaRepository alertaRepository) : base(unitOfWork.AlertaProvidenciaRepository)
        {
            this.AlertaProvidenciaRepository = alertaProvidenciaRepository;
            this.AlertaRepository = alertaRepository;
        }

        public override void Add(AlertaProvidencia obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(AlertaProvidencia obj)
        {
            
            base.Update(obj);
        }

        public async Task AddAsync(AlertaProvidencia obj)
        {
            var alerta = await this.AlertaRepository.GetByIdAsync(obj.AlertaId);
            alerta.Status = 2;
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }
    }
}