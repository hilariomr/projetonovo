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
    /// Repositório responsável pelo repositório do DadoEmpresa
    /// </summary>
    public class DadoEmpresaRepository : IDadoEmpresaRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SenaiVagasContext _ctx = new SenaiVagasContext();


        /// <summary>
        /// Lista todos os DadoEmpresa
        /// </summary>
        /// <returns>Uma lista de DadoEmpresa</returns>
        public List <DadoEmpresa> Listar()
        {
            // Retorna uma lista com todas as informações das Empresas
            return _ctx.DadoEmpresa.ToList();
        }

        /// <summary>
        /// Lista por Id os DadoEmpresa
        /// </summary>
        /// <returns>Uma lista de DadoEmpresa</returns>
        public async Task<DadoEmpresa> BuscarPorID(int id)
        {
            // Busca o primeiro evento encontrado para o ID informado e armazena no objeto eventoBuscado
            DadoEmpresa dadoEmpresaBuscado = _ctx.DadoEmpresa
            // Adiciona na busca as informações do DadoEmpresa
            .Include(e => e.IdEnderecoNavigation)
            .FirstOrDefault(e => e.IdDadoEmpresa == id);

            return await _ctx.DadoEmpresa.FindAsync(id);
        }

        public void Cadastrar(DadoEmpresa novoDadoEmpresa)
        {
            _ctx.DadoEmpresa.Add(novoDadoEmpresa);

            _ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um DadoEmpresa pelo ID
        /// </summary>
        /// <param name="id">ID do dadoEmpresa que será atualizado</param>
        /// <param name="dadoEmpresaAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, DadoEmpresa dadoEmpresaAtualizado)
        {
            // Busca um DadoEmpresa através do id
            DadoEmpresa dadoEmpresaBuscado = _ctx.DadoEmpresa.Find(id);

            // Atribui o novo valor ao campo
            dadoEmpresaBuscado.NomeEmpresa     = dadoEmpresaAtualizado.NomeEmpresa;
            dadoEmpresaBuscado.AreaDeAtuacao   = dadoEmpresaAtualizado.AreaDeAtuacao;
            dadoEmpresaBuscado.LinkSite        = dadoEmpresaAtualizado.LinkSite;
            dadoEmpresaBuscado.Descricao       = dadoEmpresaAtualizado.Descricao;
            dadoEmpresaBuscado.Fundada         = dadoEmpresaAtualizado.Fundada;
            dadoEmpresaBuscado.IdEndereco      = dadoEmpresaAtualizado.IdEndereco;
            

            // Atualiza o Dadompresa que foi buscado
            _ctx.DadoEmpresa.Update(dadoEmpresaBuscado);

            // Salva as informações para serem gravadas no banco
            _ctx.SaveChanges();
        }
        /// <summary>
        /// Deleta um DadoEmpresa
        /// </summary>
        /// <param name="id">ID do DadoEmpresa que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um DadoEmpresa através do id
            DadoEmpresa dadoEmpresaBuscado = _ctx.DadoEmpresa.Find(id);

            // Remover um DadoEmpresa que foi buscado
            _ctx.DadoEmpresa.Remove(dadoEmpresaBuscado);

            // Salva como mudanças
            _ctx.SaveChanges();
        }
    }
}
