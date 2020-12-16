using Argos.Domain.AlertaRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Argos.Service
{
    public class AlertaService : BaseService<Alerta>, IAlertaService
    {
        private readonly IAlertaRepository AlertaRepository;

        public AlertaService(IUnitOfWork unitOfWork, IAlertaRepository alertaRepository) : base(unitOfWork.AlertaRepository)
        {
            this.AlertaRepository = alertaRepository;
        }

        public override void Add(Alerta obj)
        {
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Alerta obj)
        {
            
            base.Update(obj);
        }

    }
}