using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class MinhasFormacoes
    {
        public int IdMinhasFormacoes { get; set; }
        public int? IdFormacao { get; set; }
        public int? IdDadoCandidato { get; set; }

        public DadoCandidato IdDadoCandidatoNavigation { get; set; }
        public Formacao IdFormacaoNavigation { get; set; }
    }
}
