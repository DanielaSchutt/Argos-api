using System.Threading.Tasks;
using Argos.Domain.UsuarioRoot;

namespace Argos.Domain.Interfaces.RepositoryInterfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> getByEmail(string email);
    }
}