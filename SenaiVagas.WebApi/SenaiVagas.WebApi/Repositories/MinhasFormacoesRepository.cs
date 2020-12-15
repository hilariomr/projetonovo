using Microsoft.EntityFrameworkCore;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class MinhasFormacoesRepository : IMinhasFormacoesRepository
    {

        SenaiVagasContext ctx = new SenaiVagasContext();



        public MinhasFormacoes BuscarPorId(int id)
        {
            MinhasFormacoes minhaFormacaoBuscada = ctx.MinhasFormacoes
                .Include(e => e.IdFormacaoNavigation)
                .Include(e => e.IdDadoCandidatoNavigation)
                .FirstOrDefault(e => e.IdMinhasFormacoes == id);

            return minhaFormacaoBuscada;
        }

        public List<MinhasFormacoes> BuscarPorIdDadoCandidato(int id)
        {
            List<MinhasFormacoes> minhaFormacaoBuscada = ctx.MinhasFormacoes
                .Include(e => e.IdFormacaoNavigation)
                .Where(e => e.IdDadoCandidato == id).ToList();

            return minhaFormacaoBuscada;
        }


        public List<MinhasFormacoes> Listar()
        {
            return ctx.MinhasFormacoes.Select(c => new MinhasFormacoes()
            {
                IdMinhasFormacoes = c.IdMinhasFormacoes,
                IdFormacaoNavigation = new Formacao()
                {
                    Instituicao = c.IdFormacaoNavigation.Instituicao,
                    Curso = c.IdFormacaoNavigation.Curso,
                    DataInicio = c.IdFormacaoNavigation.DataInicio,
                    DataConclusao = c.IdFormacaoNavigation.DataConclusao,

                },
                IdDadoCandidatoNavigation = new DadoCandidato()
                {
                    NomeCompleto = c.IdDadoCandidatoNavigation.NomeCompleto,
                    Curriculo = c.IdDadoCandidatoNavigation.Curriculo,
                    Foto = c.IdDadoCandidatoNavigation.Foto,

                },              
            })
                .ToList();
        }
    }
}
