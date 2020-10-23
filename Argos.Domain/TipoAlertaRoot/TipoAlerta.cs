using Argos.Domain.BaseRoot;
using Argos.Domain.AlertaRoot;
using System;
using System;
using System.Collections.Generic;


namespace Argos.Domain.TipoAlertaRoot
{
    public class TipoAlerta : Entity
    {
        public string Descricao { get; set; }
        public List<Alerta> Alertas { get; set; }


    }
}