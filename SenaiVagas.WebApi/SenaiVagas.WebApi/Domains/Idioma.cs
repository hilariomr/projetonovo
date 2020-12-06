using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Idioma
    {
        public Idioma()
        {
            MeusIdiomas = new HashSet<MeusIdiomas>();
        }

        public int IdIdioma { get; set; }
        public string Titulo { get; set; }

        public ICollection<MeusIdiomas> MeusIdiomas { get; set; }
    }
}
