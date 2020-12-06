using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            DadoCandidato = new HashSet<DadoCandidato>();
            DadoEmpresa = new HashSet<DadoEmpresa>();
        }

        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }

        public ICollection<DadoCandidato> DadoCandidato { get; set; }
        public ICollection<DadoEmpresa> DadoEmpresa { get; set; }
    }
}
