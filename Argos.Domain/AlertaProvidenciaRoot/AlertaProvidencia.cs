using Argos.Domain.BaseRoot;
using System;
using Argos.Domain.AlertaRoot;


namespace Argos.Domain.AlertaProvidenciaRoot
{
    public class AlertaProvidencia : Entity
    {
        public string Descricao { get; set; }
        public Alerta Alerta { get; set; }
        public long AlertaId { get; set; }

    }
}