using System;
using System;
using System.Collections.Generic;


namespace Argos.WebApi.ViewModels
{
    public class TipoAlertaViewModel : EntityViewModel
    {
        public string Descricao { get; set; }
        public List<AlertaViewModel> Alertas { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}