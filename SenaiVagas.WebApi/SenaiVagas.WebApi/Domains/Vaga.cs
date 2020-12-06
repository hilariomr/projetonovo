using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            Inscricao = new HashSet<Inscricao>();
        }

        public int IdVaga { get; set; }
        public string TituloVaga { get; set; }
        public string Descricao { get; set; }
        public int QuanVagas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public float Salario { get; set; }
        public string Requisitos { get; set; }
        public string LocalTrabalho { get; set; }
        public string TipoContratacao { get; set; }
        public TimeSpan EntradaDoTrabalho { get; set; }
        public TimeSpan TerminoDoTrabalho { get; set; }
        public int? IdDadoEmpresa { get; set; }

        public DadoEmpresa IdDadoEmpresaNavigation { get; set; }
        public ICollection<Inscricao> Inscricao { get; set; }
    }
}
