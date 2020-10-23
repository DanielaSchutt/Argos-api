using Argos.Domain.BaseRoot;
using System;
using Argos.Domain.UsuarioRoot;
using System.Collections.Generic;


namespace Argos.Domain.TipoUsuarioRoot
{
    public class TipoUsuario : Entity
    {
        public DateTime CriadoEm { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public string Descricao { get; set; }

    }
}