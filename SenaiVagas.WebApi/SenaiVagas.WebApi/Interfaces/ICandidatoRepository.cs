using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface ICandidatoRepository
    {
        List<Candidato> Listar();

        Candidato BuscarPorId(int id);

        void Cadastrar(Candidato NovoCandidato);

        void Deletar(int id);

        void Atualizar(int id,Candidato CandidatoAtlz);

    }
}
