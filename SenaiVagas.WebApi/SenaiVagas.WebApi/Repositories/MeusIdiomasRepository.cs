using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{

    public class MeusIdiomasRepository : IMeusIdiomasRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();
        public List<MeusIdiomas> Listar()
        {
            return ctx.MeusIdiomas.ToList();
        }


        public void Cadastrar(MeusIdiomas NovoMeusidiomas)
        {
            ctx.MeusIdiomas.Add(NovoMeusidiomas);
            ctx.SaveChanges();
        }

        public List<MeusIdiomas> ListarIdiomas()
        {
            return ctx.MeusIdiomas.Select(c => new MeusIdiomas()
            {

                IdIdiomaNavigation = new Idioma()
                {
                    Titulo = c.IdIdiomaNavigation.Titulo,
                },
                IdNivelIdiomaNavigation = new NivelIdioma()
                {
                    Titulo = c.IdNivelIdiomaNavigation.Titulo
                },

                IdDadoCandidatoNavigation = new DadoCandidato()
                {
                    TipoCarreira = c.IdDadoCandidatoNavigation.TipoCarreira,
                    PretencaoSalarial = c.IdDadoCandidatoNavigation.PretencaoSalarial,
                    ModeloContratacao = c.IdDadoCandidatoNavigation.ModeloContratacao,
                    Curriculo = c.IdDadoCandidatoNavigation.Curriculo,
                    NomeCompleto = c.IdDadoCandidatoNavigation.NomeCompleto,
                    LinkLinkedin = c.IdDadoCandidatoNavigation.LinkLinkedin,
                    LinkGit = c.IdDadoCandidatoNavigation.LinkGit,
                    LinkPortifolio = c.IdDadoCandidatoNavigation.LinkPortifolio,
                    Foto = c.IdDadoCandidatoNavigation.Foto,
                    IdEndereco = c.IdDadoCandidatoNavigation.IdEndereco,


                },
            }


            )
                .ToList();
        }

        public MeusIdiomas Buscar(int id)
        {
            // Retorna o primeiro idioma encontrado para o ID informado

            return ctx.MeusIdiomas.FirstOrDefault(e => e.IdMeusIdiomas == id);
        }

        public void Deletar(int id)
        {
            ctx.MeusIdiomas.Remove(Buscar(id));
            ctx.SaveChanges();
        }


    }
}