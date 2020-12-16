using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Argos.Domain.AlertaRoot;
using Microsoft.EntityFrameworkCore.Query;

namespace Argos.Domain.Interfaces.RepositoryInterfaces
{
    public interface IAlertaRepository : IBaseRepository<Alerta>
    {

    }
}