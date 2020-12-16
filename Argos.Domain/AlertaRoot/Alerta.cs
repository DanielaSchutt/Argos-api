using Argos.Domain.BaseRoot;
using Argos.Domain.CidadeRoot;
using System;
using System;
using Argos.Domain.TipoAlertaRoot;
using Argos.Domain.CameraLogRoot;
using System.Collections.Generic;
using Argos.Domain.UsuarioRoot;


namespace Argos.Domain.AlertaRoot
{
    public class Alerta : Entity
    {
        public Cidade Cidade { get; set; }
        public long CidadeId { get; set; }
        public TipoAlerta Tipo { get; set; }
        public long TipoId { get; set; }
        public string Titulo { get; set; }
        public List<CameraLog> Logs { get; set; }
        public string Placa { get; set; }
        public string Area { get; set; }
        public int Status { get; set; }
        
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}