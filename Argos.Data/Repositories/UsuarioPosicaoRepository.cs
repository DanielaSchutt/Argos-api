using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.UsuarioPosicaoRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class UsuarioPosicaoRepository : BaseRepository<UsuarioPosicao>,  IUsuarioPosicaoRepository
    {
        public UsuarioPosicaoRepository(DataContext context) : base(context) { }
    }
}