using System.Threading.Tasks;
using Argos.Domain.UsuarioRoot;

namespace Argos.Domain.Interfaces.ServiceInterfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<Usuario> AuthenticateAsync(UsuarioModel obj);
    }
}