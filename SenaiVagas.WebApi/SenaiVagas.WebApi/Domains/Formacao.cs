using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class Formacao
    {
        public Formacao()
        {
            MinhasFormacoes = new HashSet<MinhasFormacoes>();
        }

        public int IdFormacao { get; set; }
        public string Instituicao { get; set; }
        public string Curso { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }

        public ICollection<MinhasFormacoes> MinhasFormacoes { get; set; }
    }
}
