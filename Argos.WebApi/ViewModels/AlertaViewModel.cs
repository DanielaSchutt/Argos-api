using System;
using System;
using System.Collections.Generic;
using Argos.Domain.UsuarioRoot;


namespace Argos.WebApi.ViewModels
{
    public class AlertaViewModel : EntityViewModel
    {
        public CidadeViewModel Cidade { get; set; }
        public long CidadeId { get; set; }
        public DateTime CriadoEm { get; set; }
        public TipoAlertaViewModel Tipo { get; set; }
        public long TipoId { get; set; }
        public string Titulo { get; set; }
        public List<CameraLogViewModel> Logs { get; set; }
        public string Placa { get; set; }
        public string Area { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}