using System;
using System;
using System.Collections.Generic;


namespace Argos.WebApi.ViewModels
{
    public class CidadeViewModel : EntityViewModel
    {
        public DateTime CriadoEm { get; set; }
        public string Nome { get; set; }
        public List<AlertaViewModel> Alertas { get; set; }
        public EstadoViewModel Estado { get; set; }
        public long EstadoId { get; set; }

    }
}