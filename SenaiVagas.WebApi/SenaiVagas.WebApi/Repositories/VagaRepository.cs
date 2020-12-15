using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;

namespace SenaiVagas.WebApi.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();
        public void Atualizar(int id, Vaga vagaAtualizada)
        {
            Vaga vagaBuscada = ctx.Vaga.Find(id);

            vagaBuscada.Descricao = vagaAtualizada.Descricao;

            vagaBuscada.QuanVagas = vagaAtualizada.QuanVagas;

            vagaBuscada.DataInicio = vagaAtualizada.DataInicio;

            vagaBuscada.DataTermino = vagaAtualizada.DataTermino;

            vagaBuscada.Salario = vagaAtualizada.Salario;

            vagaBuscada.Requisitos = vagaAtualizada.Requisitos;

            vagaBuscada.LocalTrabalho = vagaAtualizada.LocalTrabalho;

            vagaBuscada.TipoContratacao = vagaAtualizada.TipoContratacao;

            vagaBuscada.EntradaDoTrabalho = vagaAtualizada.EntradaDoTrabalho;

            vagaBuscada.TerminoDoTrabalho = vagaAtualizada.TerminoDoTrabalho;

            ctx.Vaga.Update(vagaBuscada);

            ctx.SaveChanges();

        }

        public Vaga BuscarPorId(int id)
        {
            return ctx.Vaga.FirstOrDefault(a => a.IdVaga == id);
        }

        public void Cadastrar(Vaga novaVaga)
        {
            ctx.Vaga.Add(novaVaga);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Vaga.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Vaga> BuscarPorEmpresa(int id)
        {
            List<Vaga> vagas = ctx.Vaga.Where(e => e.IdDadoEmpresa == id)
                .Select(c => new Vaga()
                {
                    IdVaga = c.IdVaga,
                    TituloVaga = c.TituloVaga,
                    Descricao = c.Descricao,
                    QuanVagas = c.QuanVagas,
                    DataInicio = c.DataInicio,
                    DataTermino = c.DataTermino,
                    Salario = c.Salario,
                    Requisitos = c.Requisitos,
                    LocalTrabalho = c.LocalTrabalho,
                    TipoContratacao = c.TipoContratacao,
                    EntradaDoTrabalho = c.EntradaDoTrabalho,
                    TerminoDoTrabalho = c.TerminoDoTrabalho,
                    IdDadoEmpresaNavigation = new DadoEmpresa()
                    {
                        NomeEmpresa = c.IdDadoEmpresaNavigation.NomeEmpresa,
                    }
                }).ToList();
            return vagas;
        }

        public List<Vaga> Listar()
        {
            return ctx.Vaga.Select(c => new Vaga()
            {
                IdVaga = c.IdVaga,
                TituloVaga = c.TituloVaga,
                Descricao = c.Descricao,
                QuanVagas = c.QuanVagas,
                DataInicio = c.DataInicio,
                DataTermino = c.DataTermino,
                Salario = c.Salario,
                Requisitos = c.Requisitos,
                LocalTrabalho = c.LocalTrabalho,
                TipoContratacao = c.TipoContratacao,
                EntradaDoTrabalho = c.EntradaDoTrabalho,
                TerminoDoTrabalho = c.TerminoDoTrabalho,
                IdDadoEmpresaNavigation = new DadoEmpresa()
                { 
                    NomeEmpresa = c.IdDadoEmpresaNavigation.NomeEmpresa,
                }
            })
                    .ToList();
        }

    }
}
