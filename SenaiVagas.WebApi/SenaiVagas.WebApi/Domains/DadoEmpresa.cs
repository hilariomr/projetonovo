using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class DadoEmpresa
    {
        public DadoEmpresa()
        {
            Empresa = new HashSet<Empresa>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdDadoEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string AreaDeAtuacao { get; set; }
        public string LinkSite { get; set; }
        public string Descricao { get; set; }
        public string Fundada { get; set; }
        public string TipoEmpresa { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
        public int? IdEndereco { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
        public ICollection<Empresa> Empresa { get; set; }
        public ICollection<Vaga> Vaga { get; set; }
    }
}
