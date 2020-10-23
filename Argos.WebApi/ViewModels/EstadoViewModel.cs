using System;
using System;
using System.Collections.Generic;


namespace Argos.WebApi.ViewModels
{
    public class EstadoViewModel : EntityViewModel
    {
        public string Nome { get; set; }
        public List<CidadeViewModel> Cidades { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}