using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IDadoCandidatoRepository
    {

        List<DadoCandidato> Listar();

        DadoCandidato BuscarPorId(int id);

        void Cadastrar(DadoCandidato NovoDadoCandidato);

        void Deletar(int id);

        void Atualizar(int id, DadoCandidato DadoCandidatoAtlz);

    }
}
