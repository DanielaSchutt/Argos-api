using System;


namespace Argos.WebApi.ViewModels
{
    public class UsuarioPosicaoViewModel : EntityViewModel
    {
        public long UsuarioId { get; set; }
        public DateTime CriadoEm { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}