using Argos.Domain.TipoUsuarioRoot;

namespace Argos.Domain.UsuarioRoot
{
    public class UsuarioModel
    {
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string TokenFirebase { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool IsRevoked { get; set; }
        
    }
}