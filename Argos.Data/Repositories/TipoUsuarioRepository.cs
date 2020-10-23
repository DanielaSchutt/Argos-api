using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.TipoUsuarioRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;


namespace Argos.Data.Repositories
{
    public class TipoUsuarioRepository : BaseRepository<TipoUsuario>,  ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(DataContext context) : base(context) { }
    }
}