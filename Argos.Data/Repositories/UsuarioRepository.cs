using System.Collections.Generic;
using System.Threading.Tasks;
using Argos.Domain.UsuarioRoot;
using Argos.Data.Context;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;


namespace Argos.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>,  IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context) { }

        public async Task<Usuario> getByEmail(string email)
        {
            var usuario = await DbSet.SingleOrDefaultAsync(x => x.Email == email);
            return usuario;
        }
    }
}