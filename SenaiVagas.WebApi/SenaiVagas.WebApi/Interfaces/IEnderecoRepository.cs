using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IEnderecoRepository
    {
        List<Endereco> Listar();

        void Cadastrar(Endereco novoEndereco);

        void Atualizar(int id, Endereco enderecoAtualizado);

        void Deletar(int id);

        Endereco BuscarPorId(int id);
    }
}
