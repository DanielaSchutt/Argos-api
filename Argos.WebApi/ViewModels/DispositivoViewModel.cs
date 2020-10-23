using System;
using System;


namespace Argos.WebApi.ViewModels
{
    public class DispositivoViewModel : EntityViewModel
    {
        public string Versao { get; set; }
        public long UsuarioId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Codigo { get; set; }

    }
}