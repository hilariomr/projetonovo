using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IAdministradorRepository
    {
        List<Administrador> Listar();

        void Cadastrar(Administrador novoAdmin);

        void Atualizar(int id, Administrador adminAtualizado);

        void Deletar(int id);

        Administrador BuscarPorId(int id);
    }
}

