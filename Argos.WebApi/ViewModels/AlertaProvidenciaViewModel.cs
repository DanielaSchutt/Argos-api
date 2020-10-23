using System;


namespace Argos.WebApi.ViewModels
{
    public class AlertaProvidenciaViewModel : EntityViewModel
    {
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public AlertaViewModel Alerta { get; set; }
        public long AlertaId { get; set; }

    }
}