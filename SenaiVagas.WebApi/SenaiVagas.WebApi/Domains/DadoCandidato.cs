using System;
using System.Collections.Generic;

namespace SenaiVagas.WebApi.Domains
{
    public partial class DadoCandidato
    {
        public DadoCandidato()
        {
            Candidato = new HashSet<Candidato>();
            MeusIdiomas = new HashSet<MeusIdiomas>();
            MinhasFormacoes = new HashSet<MinhasFormacoes>();
        }

        public int IdDadoCandidato { get; set; }
        public string TipoCarreira { get; set; }
        public double PretencaoSalarial { get; set; }
        public string ModeloContratacao { get; set; }
        public string TipoTrabalho { get; set; }
        public string Curriculo { get; set; }
        public string NomeCompleto { get; set; }
        public string LinkLinkedin { get; set; }
        public string LinkGit { get; set; }
        public string LinkPortifolio { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public int? IdEndereco { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
        public ICollection<Candidato> Candidato { get; set; }
        public ICollection<MeusIdiomas> MeusIdiomas { get; set; }
        public ICollection<MinhasFormacoes> MinhasFormacoes { get; set; }
    }
}
