using Argos.Domain.BaseRoot;
using Argos.Domain.CidadeRoot;
using System;
using System;
using System.Collections.Generic;


namespace Argos.Domain.EstadoRoot
{
    public class Estado : Entity
    {
        public string Nome { get; set; }
        public List<Cidade> Cidades { get; set; }


    }
}