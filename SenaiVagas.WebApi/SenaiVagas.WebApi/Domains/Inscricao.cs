using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }
        public DateTime DataInscricao { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdVaga { get; set; }

        public Candidato IdCandidatoNavigation { get; set; }
        public Vaga IdVagaNavigation { get; set; }
    }
}
