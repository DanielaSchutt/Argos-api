using System;
using System;
using System.Collections.Generic;


namespace Argos.WebApi.ViewModels
{
    public class UsuarioViewModel : EntityViewModel
    {
        public DateTime CriadoEm { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public List<UsuarioPosicaoViewModel> Posicoes { get; set; }
        public TipoUsuarioViewModel Tipo { get; set; }
        public long TipoId { get; set; }
        public string Matricula { get; set; }
        public List<DispositivoViewModel> Dispositivos { get; set; }
        public string Nome { get; set; }
        public string PasswordHash { get; set; }

    }
}