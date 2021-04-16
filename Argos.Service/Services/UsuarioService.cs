using Argos.Domain.UsuarioRoot;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Threading.Tasks;
using Argos.Authentication;

namespace Argos.Service
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository) : base(unitOfWork.UsuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }

        public override void Add(Usuario obj)
        {
            obj.PasswordHash = CryptoPassword.Encriptar(obj.Senha);
            obj.CriadoEm = DateTime.Now;
            base.Add(obj);
        }

        public override void Update(Usuario obj)
        {
            obj.PasswordHash = CryptoPassword.Encriptar(obj.Senha);
            base.Update(obj);
        }

        public async Task<Usuario> AuthenticateAsync(UsuarioModel obj)
        {
            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrEmpty(obj.Senha))
                return null;

            var user = await this.UsuarioRepository.getByEmail(obj.Email);

            if (user == null)
                return null;
           
            if (!CryptoPassword.VerifyPassword(user.PasswordHash, obj.Senha))
                return null;

            if (!string.IsNullOrEmpty(obj.TokenFirebase))
            {
                user.TokenFirebase = obj.TokenFirebase;

            }
            base.Update(user);

            return user;
        }
    }
}