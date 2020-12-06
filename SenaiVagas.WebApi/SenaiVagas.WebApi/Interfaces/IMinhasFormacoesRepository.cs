using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IMinhasFormacoesRepository
    {
        List<MinhasFormacoes> Listar();

        MinhasFormacoes BuscarPorId(int id);

    }
}
