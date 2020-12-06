using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;


namespace SenaiVagas.WebApi.Interfaces
{
    interface IEmpresaRepository
    {
        ///<summary>
        ///Listar todos as Empresas
        ///</summary>
        ///<returns> Retornar uma lista com as Empresas </returns>
        List <Empresa> Listar();

        /// <summary>
        /// Busca um tipo de Empresa através do seu id
        /// </summary>
        /// <param  name = " id " > Identificador específico da empresa </param>
        /// <summary> Retorna uma empresa buscado </summary>
        Task<Empresa> BuscarPorID(int id);


        /// <summary>
        /// Cadastra uma empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto empresa com os dados que serão cadastrados</param>
        /// <returns>Retorna uma Empresa cadastrado</returns>
        void Cadastrar(Empresa novaEmpresa);

        /// <summary>
        /// Atualiza uma Empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Empresa empresaAtualizado);
            

        /// <summary >
        /// Deleta uma Empresa
        /// </summary >
        /// <param  name = " id " > ID da Empresa que será deletado </param>
        void Deletar(int id);

    }
}
