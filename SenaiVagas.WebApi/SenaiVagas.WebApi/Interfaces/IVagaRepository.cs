using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IVagaRepository
    {
        List<Vaga> Listar();

        void Cadastrar(Vaga novaVaga);

        void Atualizar(int id, Vaga vagaAtualizada);

        void Deletar(int id);

        Vaga BuscarPorId(int id);

        List<Vaga> BuscarPorEmpresa(int idDadoEmpresa);
    }
}
