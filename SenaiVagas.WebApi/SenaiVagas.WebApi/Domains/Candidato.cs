using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            Inscricao = new HashSet<Inscricao>();
        }

        public int IdCandidato { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public int? IdDadoCandidato { get; set; }

        public DadoCandidato IdDadoCandidatoNavigation { get; set; }
        public ICollection<Inscricao> Inscricao { get; set; }
    }
}
