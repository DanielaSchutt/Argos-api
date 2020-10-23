using System;
using System;
using System.Collections.Generic;


namespace Argos.WebApi.ViewModels
{
    public class CameraViewModel : EntityViewModel
    {
        public DateTime CriadoEm { get; set; }
        public decimal Latitude { get; set; }
        public bool Status { get; set; }
        public decimal Longitude { get; set; }
        public string Nome { get; set; }
        public List<CameraLogViewModel> Log { get; set; }

    }
}