using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IFormacaoRepository
    {
        List<Formacao> Listar();

        Formacao BuscarPorId(int id);

        void Cadastrar(Formacao novoFormacao);

        void Deletar(int id);

        void Atualizar(int id, Formacao formacao);

    }
}
