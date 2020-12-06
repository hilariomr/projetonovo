using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IidiomaRepository
    {
        List<Idioma> Listar();
        void Cadastrar(Idioma idioma);
        Idioma Buscar(int id);

        void Atualizar(Idioma idiomaAtualizado, int id);
        // deletando pelo id (url do postman)
        void Deletar(int id);
    }
}