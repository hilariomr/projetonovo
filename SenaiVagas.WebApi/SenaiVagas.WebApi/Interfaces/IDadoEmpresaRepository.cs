using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;

namespace SenaiVagas.WebApi.Interfaces
{
    interface IDadoEmpresaRepository
    {
        ///<summary>
        ///Listar todos os DadoEmpresa
        ///</summary>
        ///<return> Retornar uma lista com os DadoEmpresa</return>
        List <DadoEmpresa> Listar();

        /// <summary>5
        /// Busca um tipo de DadoEmpresa através do seu id
        /// </summary>
        /// <param  name = " id " > Identificador específico do DadoEmpresa </param>
        /// <summary> Retorna um DadoEmpresa buscado </summary>
        Task <DadoEmpresa> BuscarPorID(int id);


        /// <summary>
        /// Cadastra um DadoEmpresa
        /// </summary>
        /// <param name="novoDadoEmpresa">Objeto DadoEmpresa com os dados que serão cadastrados</param>
        /// <returns>Retorna um DadoEmpresa cadastrado</returns>
        void Cadastrar(DadoEmpresa novoDadoEmpresa);

        /// <summary>
        /// Atualiza um DadoEmpresa existente
        /// </summary>
        /// <param name="id">ID do DAdoEmpresa que será atualizado</param>
        /// <param name="dadoEmpresaAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, DadoEmpresa dadoEmpresaAtualizado);


        /// <summary >
        /// Deleta um DadoEmpresa
        /// </summary >
        /// <param  name = "id" > ID do DadoEmpresa que será deletado </param>
        void Deletar(int id);
    }
}
