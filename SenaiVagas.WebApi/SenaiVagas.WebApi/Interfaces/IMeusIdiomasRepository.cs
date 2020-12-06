using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IMeusIdiomasRepository
    {
        List<MeusIdiomas> ListarIdiomas();
        void Cadastrar(MeusIdiomas NovoMeusidiomas);
        MeusIdiomas Buscar(int id);

        // deletando pelo id (url do postman)
        void Deletar(int id);
    }
}