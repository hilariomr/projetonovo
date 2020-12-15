using Microsoft.EntityFrameworkCore;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {

        SenaiVagasContext ctx = new SenaiVagasContext();

        public IEnumerable<Inscricao> BuscarIncricoesDaVaga(int idVaga)
        {
            var inscricoes = ctx.Inscricao.Include(i => i.IdCandidatoNavigation).Include(i => i.IdVagaNavigation).Where(i => i.IdVaga == idVaga);

            if (inscricoes.Count() == 0)
            {
                return null;
            }

            return inscricoes;
            

        }

        public IEnumerable<Inscricao> BuscarIncricoesDoCandidato(int idCandidato)
        {
            var inscricoes = ctx.Inscricao.Include(i => i.IdCandidatoNavigation).Include(i => i.IdVagaNavigation).Where(i => i.IdCandidato == idCandidato);

            if (inscricoes.Count() == 0)
            {
                return null;
            }

            return inscricoes;
        }

        public Inscricao BuscarPorId(int id)
        {
                Inscricao inscricaoBuscada = ctx.Inscricao
               .Include(e => e.IdCandidatoNavigation)
               .Include(e => e.IdVagaNavigation)
               .FirstOrDefault(e => e.IdInscricao == id);

            return inscricaoBuscada;
        }

        public void Cadastrar(Inscricao novoInscricao)
        {
            novoInscricao.DataInscricao = DateTime.Now;
            ctx.Inscricao.Add(novoInscricao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Inscricao inscricaoApagada = new Inscricao();
            inscricaoApagada = BuscarPorId(id);
            ctx.Inscricao.Remove(inscricaoApagada);
            ctx.SaveChanges();
        }

        public List<Inscricao> Listar()
        {
            return ctx.Inscricao.Select(c => new Inscricao()
            {
                IdInscricao = c.IdInscricao,
                IdCandidatoNavigation = new Candidato()
                {
                    Email = c.IdCandidatoNavigation.Email,
                    Cpf = c.IdCandidatoNavigation.Cpf,
                    IdDadoCandidatoNavigation = new DadoCandidato()
                    {
                        NomeCompleto = c.IdCandidatoNavigation.IdDadoCandidatoNavigation.NomeCompleto,
                    }

                },
                IdVagaNavigation = new Vaga()
                {
                    Descricao = c.IdVagaNavigation.Descricao,
                    QuanVagas = c.IdVagaNavigation.QuanVagas,
                    Salario = c.IdVagaNavigation.Salario,
                    Requisitos = c.IdVagaNavigation.Requisitos,
                    LocalTrabalho = c.IdVagaNavigation.LocalTrabalho,
                    TipoContratacao = c.IdVagaNavigation.TipoContratacao,
                    IdDadoEmpresaNavigation = new DadoEmpresa()
                    {
                        NomeEmpresa = c.IdVagaNavigation.IdDadoEmpresaNavigation.NomeEmpresa,
                    }


                },
            })
               .ToList();

        }
    }
}
