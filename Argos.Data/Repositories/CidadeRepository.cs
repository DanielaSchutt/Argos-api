using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.CidadeRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>,  ICidadeRepository
    {
        public CidadeRepository(DataContext context) : base(context) { }
    }
}