using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Argos.Domain.AlertaRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


namespace Argos.Data.Repositories
{
    public class AlertaRepository : BaseRepository<Alerta>,  IAlertaRepository
    {
        public AlertaRepository(DataContext context) : base(context) { }
        
    }
}