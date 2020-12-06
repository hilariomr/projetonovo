using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;

namespace SenaiVagas.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelo repositório das Empresas
    /// </summary>
    public class EmpresaRepository: IEmpresaRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SenaiVagasContext _ctx = new SenaiVagasContext();


        /// <summary>
        /// Lista todos as Empresas
        /// </summary>
        /// <returns>Uma lista das empresas</returns>
        public List <Empresa> Listar()
        {
            // Retorna uma lista com todas as informações das Empresas
            return _ctx.Empresa.ToList();
        }

        public async Task<Empresa> BuscarPorID(int id)
        {

            // Busca o primeiro evento encontrado para o ID informado e armazena no objeto eventoBuscado
            Empresa empresaBuscado = _ctx.Empresa
            // Adiciona na busca as informações do DadoEmpresa
            .Include(e => e.IdDadoEmpresaNavigation)
            .FirstOrDefault(e => e.IdEmpresa == id);

            return await _ctx.Empresa.FindAsync(id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
             _ctx.Empresa.Add(novaEmpresa);
               
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma Empresa pelo ID
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Empresa empresaAtualizado)
        {
            // Busca uma Empresa através do id
            Empresa empresaBuscado = _ctx.Empresa.Find(id);

            // Atribui o novo valor ao campo
            empresaBuscado.Email = empresaAtualizado.Email;
            empresaBuscado.Cnpj = empresaAtualizado.Cnpj;
            empresaBuscado.Senha = empresaAtualizado.Senha;
            empresaBuscado.IdDadoEmpresa = empresaAtualizado.IdDadoEmpresa;

            // Atualiza a Empresa que foi buscado
            _ctx.Empresa.Update(empresaBuscado);

            // Salva as informações para serem gravadas no banco
            _ctx.SaveChanges();
        }
        /// <summary>
        /// Deleta uma Empresa
        /// </summary>
        /// <param name="id">ID da Empresa que será deletado</param>
        public void Deletar(int id)
        {
            // Busca uma Empresa através do id
            Empresa empresaBuscado = _ctx.Empresa.Find(id);

            // Remover a Empresa que foi buscado
            _ctx.Empresa.Remove(empresaBuscado);

            // Salva como mudanças
            _ctx.SaveChanges();
        }
    }
}
