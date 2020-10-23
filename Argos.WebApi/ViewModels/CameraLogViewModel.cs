using System;
using System;


namespace Argos.WebApi.ViewModels
{
    public class CameraLogViewModel : EntityViewModel
    {
        public AlertaViewModel Alerta { get; set; }
        public long AlertaId { get; set; }
        public CameraViewModel Camera { get; set; }
        public long CameraId { get; set; }
        public DateTime Data { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}