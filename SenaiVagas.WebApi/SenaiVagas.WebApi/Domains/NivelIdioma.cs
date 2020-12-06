using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class NivelIdioma
    {
        public NivelIdioma()
        {
            MeusIdiomas = new HashSet<MeusIdiomas>();
        }

        public int IdNivelIdioma { get; set; }
        public string Titulo { get; set; }

        public ICollection<MeusIdiomas> MeusIdiomas { get; set; }
    }
}
