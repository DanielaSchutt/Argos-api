using Argos.Domain.BaseRoot;
using Argos.Domain.AlertaRoot;
using Argos.Domain.CameraRoot;
using System;
using System;


namespace Argos.Domain.CameraLogRoot
{
    public class CameraLog : Entity
    {
        public Alerta Alerta { get; set; }
        public long AlertaId { get; set; }
        public Camera Camera { get; set; }
        public long CameraId { get; set; }
        public DateTime Data { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}