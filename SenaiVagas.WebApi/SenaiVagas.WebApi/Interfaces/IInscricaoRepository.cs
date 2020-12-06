using SenaiVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IInscricaoRepository
    {
        List<Inscricao> Listar();

        Inscricao BuscarPorId(int id);

        void Cadastrar(Inscricao novoInscricao);

        void Deletar(int id);

        // Retorna Uma lista de todas as inscrições do candidato
        IEnumerable<Inscricao> BuscarIncricoesDoCandidato(int idCandidato);

        // Retorna uma lista com todas as inscrições que a vaga recebeu
        IEnumerable<Inscricao> BuscarIncricoesDaVaga(int idVaga);


    }
}
