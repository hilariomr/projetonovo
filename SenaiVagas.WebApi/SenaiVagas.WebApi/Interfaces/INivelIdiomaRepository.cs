using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface INivelIdiomaRepository
    {

        List<NivelIdioma> ListarIdiomas();
        void Cadastrar(NivelIdioma idioma);
        NivelIdioma Buscar(int id);
        void Atualizar(NivelIdioma idiomaAtualizado, int id);
        // deletando pelo id (url do postman)
        void Deletar(int id);
    }
}