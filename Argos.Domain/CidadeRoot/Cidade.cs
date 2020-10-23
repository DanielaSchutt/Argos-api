using Argos.Domain.BaseRoot;
using System;
using System;
using Argos.Domain.AlertaRoot;
using Argos.Domain.EstadoRoot;
using System.Collections.Generic;


namespace Argos.Domain.CidadeRoot
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }
        public List<Alerta> Alertas { get; set; }
        public Estado Estado { get; set; }
        public long EstadoId { get; set; }

    }
}