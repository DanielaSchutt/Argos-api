using Argos.Domain.BaseRoot;
using Argos.Domain.UsuarioRoot;
using System;
using System;


namespace Argos.Domain.DispositivoRoot
{
    public class Dispositivo : Entity
    {
        public string Versao { get; set; }
        public Usuario Usuario { get; set; }
        public long UsuarioId { get; set; }
        public string Codigo { get; set; }

    }
}