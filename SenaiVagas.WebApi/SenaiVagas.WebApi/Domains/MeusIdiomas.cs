using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class MeusIdiomas
    {
        public int IdMeusIdiomas { get; set; }
        public int? IdIdioma { get; set; }
        public int? IdNivelIdioma { get; set; }
        public int? IdDadoCandidato { get; set; }

        public DadoCandidato IdDadoCandidatoNavigation { get; set; }
        public Idioma IdIdiomaNavigation { get; set; }
        public NivelIdioma IdNivelIdiomaNavigation { get; set; }
    }
}
