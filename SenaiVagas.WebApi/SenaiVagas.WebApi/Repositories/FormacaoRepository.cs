using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class FormacaoRepository : IFormacaoRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();

        public Formacao BuscarPorId(int id)
        {
            return ctx.Formacao.FirstOrDefault(e => e.IdFormacao == id);
        }

        public List<Formacao> Listar()
        {
            return ctx.Formacao.ToList();
        }

        public void Cadastrar(Formacao novoFormacao)
        {
            ctx.Formacao.Add(novoFormacao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Formacao formacaoApagada = new Formacao();
            formacaoApagada = BuscarPorId(id);
            ctx.Formacao.Remove(formacaoApagada);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Formacao formacao)
        {
            Formacao formacaoAtualizada = new Formacao();
            formacaoAtualizada = BuscarPorId(id);
            formacaoAtualizada.Instituicao = formacao.Instituicao;
            formacaoAtualizada.Curso = formacao.Curso;
            formacaoAtualizada.DataInicio = formacao.DataInicio;
            formacaoAtualizada.DataConclusao = formacao.DataConclusao;
            ctx.Formacao.Update(formacaoAtualizada);
            ctx.SaveChanges();

        }
    }
}
