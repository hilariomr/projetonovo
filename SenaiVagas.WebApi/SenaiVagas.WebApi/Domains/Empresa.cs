using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Senha { get; set; }
        public int? IdDadoEmpresa { get; set; }

        public DadoEmpresa IdDadoEmpresaNavigation { get; set; }
    }
}
