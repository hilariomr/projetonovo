using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.Repositories;

namespace SenaiVagas.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes as Vagas
    /// </summary>

    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VagaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _vagaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IVagaRepository _vagaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public VagaController()
        {
            _vagaRepository = new VagaRepository();
        }

        /// <summary>
        /// Lista todas as vagas
        /// </summary>
        /// <returns>Uma lista de vagas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de vagas</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_vagaRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Lista todas as vagas por Dado Empresa
        /// </summary>
        /// <returns>Uma lista de vagas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de vagas</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga
        [HttpGet("dadoEmpresa/{id}")]
        public IActionResult GetDadoEmpresa(int id)
        {
            try
            {
                return Ok(_vagaRepository.BuscarPorEmpresa(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Busca uma vaga através do ID
        /// </summary>
        /// <param name="id">ID da vaga que será buscada</param>
        /// <returns>Um vaga buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o vaga buscada</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(200, _vagaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Cadastra uma nova vaga
        /// </summary>
        /// <param name="novaVaga">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga
        [Authorize(Roles = "EMPRESA")]
        [HttpPost]
        public IActionResult Post(Vaga novaVaga)
        {
            try
            {
                _vagaRepository.Cadastrar(novaVaga);
                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Atualiza uma vaga existente
        /// </summary>
        /// <param name="id">ID da vaga que será atualizada</param>
        /// <param name="vagaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga/id
        [Authorize(Roles = "EMPRESA")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Vaga vagaAtualizada)
        {
            Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);
            if (vagaAtualizada != null)
            {
                try
                {
                    _vagaRepository.Atualizar(id, vagaAtualizada);

                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }
            }
            return NotFound("Nenhuma vaga encontrada para o ID informado");
        }

        /// <summary>
        /// Deleta uma vaga existente
        /// </summary>
        /// <param name="id">ID da vaga que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Vaga/id
        [Authorize(Roles = "EMPRESA")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

            if (vagaBuscada != null)
            {
                try
                {
                    _vagaRepository.Deletar(id);
                    return StatusCode(202);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }
            }
            return NotFound("Nenhuma vaga encontrada para o ID informado");
        }
    }
}
