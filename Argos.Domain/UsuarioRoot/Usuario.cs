using Argos.Domain.BaseRoot;
using System;
using System;
using Argos.Domain.UsuarioPosicaoRoot;
using Argos.Domain.TipoUsuarioRoot;
using Argos.Domain.DispositivoRoot;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Argos.Domain.UsuarioRoot
{
    public class Usuario : Entity
    {
        public string Email { get; set; }
        public string Cpf { get; set; }
        public List<UsuarioPosicao> Posicoes { get; set; }
        public TipoUsuario Tipo { get; set; }
        public long TipoId { get; set; }
        public string Matricula { get; set; }
        public List<Dispositivo> Dispositivos { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        public string PasswordHash { get; set; }

    }
}