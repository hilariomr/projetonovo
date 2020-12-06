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
    public class DadoEmpresaController : ControllerBase
    {
        DadoEmpresaRepository _repositorio = new DadoEmpresaRepository();

        /// <summary>
        /// Lista todos os DadoEmpresa
        /// </summary>
        /// <returns>Retorna uma lista dos DadoEmpresa</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public ActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_repositorio.Listar());
        }

        /// <summary>
        /// Busca um DadoEmpresaatravés do seu ID
        /// </summary>
        /// <param name="id">Identificador único do DadoEmpresa que será buscado</param>
        /// <returns>Retorna um DadoEmpresa buscado</returns>
        [Authorize(Roles = "EMPRESA")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DadoEmpresa>> Get(int id)
        {
            DadoEmpresa dadoEmpresa = await _repositorio.BuscarPorID(id);

            if (dadoEmpresa == null)
            {
                return NotFound();
            }

            return dadoEmpresa;
        }

        /// <summary>
        /// Cadastra um novo DadoEmpresa
        /// </summary>
        /// <param name="novoDadoEmpresa">Objeto dadoEmpresa que será cadastrado</param>
        /// <returns>Retorna os dados do DadoEmpresa que foi cadastrado</returns>
        [HttpPost]
        public ActionResult Post(DadoEmpresa novoDadoEmpresa)
        {

            _repositorio.Cadastrar(novoDadoEmpresa);

            return StatusCode(201, novoDadoEmpresa);

        }

        /// <summary>
        /// Atualiza um DadoEmpresa existente
        /// </summary>
        /// <param name="id">ID do DadoEmpresa que será atualizado</param>
        /// <param name="dadoEmpresaAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "EMPRESA")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, DadoEmpresa dadoEmpresaAtualizado)
        {
            // Faz a chamada para o método
            _repositorio.Atualizar(id, dadoEmpresaAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um DadoEmpresa
        /// </summary>
        /// <param name="id">ID do DadoEmpresa que será deletado</param>
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
