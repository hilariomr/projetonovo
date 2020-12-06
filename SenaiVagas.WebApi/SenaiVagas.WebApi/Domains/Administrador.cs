using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public string NomeAdm { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
