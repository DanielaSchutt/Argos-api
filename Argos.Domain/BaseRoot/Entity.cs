using System;

namespace Argos.Domain.BaseRoot
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}