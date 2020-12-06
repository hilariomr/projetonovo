using System.Collections.Generic;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaiVagas.WebApi.Repositories;

namespace SenaiVagas.WebApi.Controllers
{

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        EmpresaRepository _repositorio = new EmpresaRepository();

        /// <summary>
        /// Lista todos as DadoEmpresa
        /// </summary>
        /// <returns>Retorna uma lista dos DadoEmpresa</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public ActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok( _repositorio.Listar());
        }

        /// <summary>
        /// Busca um Empresa através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da Empresa que será buscado</param>
        /// <returns>Retorna uma Empresa buscado</returns>
        [Authorize(Roles = "EMPRESA")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            Empresa empresa = await _repositorio.BuscarPorID(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        /// <summary>
        /// Cadastra uma nova Empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto empresa que será cadastrado</param>
        /// <returns>Retorna os dados da Empresa que foi cadastrado</returns>
        [HttpPost]
        public ActionResult  Post(Empresa novaEmpresa)
        {
           
             _repositorio.Cadastrar(novaEmpresa);

            return StatusCode(201);

        }

        /// <summary>
        /// Atualiza uma Empresa existente
        /// </summary>
        /// <param name="id">ID da Empresa que será atualizado</param>
        /// <param name="dadoEmpresaAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "EMPRESA")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Empresa dadoEmpresaAtualizado)
        {
            // Faz a chamada para o método
            _repositorio.Atualizar(id, dadoEmpresaAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma Empresa
        /// </summary>
        /// <param name="id">ID da Empresa que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "EMPRESA")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _repositorio.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }


    }
}
