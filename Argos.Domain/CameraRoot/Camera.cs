using Argos.Domain.BaseRoot;
using System;
using Argos.Domain.CameraLogRoot;
using System;
using System.Collections.Generic;


namespace Argos.Domain.CameraRoot
{
    public class Camera : Entity
    {
        public double Latitude { get; set; }
        public bool Status { get; set; }
        public double Longitude { get; set; }
        public string Nome { get; set; }
        public List<CameraLog> Log { get; set; }

    }
}