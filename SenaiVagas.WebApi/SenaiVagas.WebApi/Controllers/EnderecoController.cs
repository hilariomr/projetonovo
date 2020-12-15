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
    /// Controller responsável pelos endpoints referentes aos Endereços
    /// </summary>

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _enderecoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEnderecoRepository _enderecoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Lista todos os endereços
        /// </summary>
        /// <returns>Uma lista de endereços e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de endereços</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Endereco
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_enderecoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        /// <summary>
        /// Cadastra um novo endereço
        /// </summary>
        /// <param name="novoEndereco">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Endereco
        [HttpPost]
        public IActionResult Post(Endereco novoEndereco)
        {
            try
            {
                _enderecoRepository.Cadastrar(novoEndereco);
                return StatusCode(201, novoEndereco);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Busca um endereço através do ID
        /// </summary>
        /// <param name="id">ID do endereço que será buscado</param>
        /// <returns>Um endereço buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o endereço buscado</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Endereco/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(200, _enderecoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Atualiza um endereço existente
        /// </summary>
        /// <param name="id">ID do endereço que será atualizado</param>
        /// <param name="enderecoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Endereco/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Endereco enderecoAtualizado)
        {
            Endereco enderecoBuscado = _enderecoRepository.BuscarPorId(id);

            if (enderecoBuscado != null)
            {
                try
                {
                    _enderecoRepository.Atualizar(id, enderecoAtualizado);

                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }
            }
            return NotFound("Nenhum endereço encontrado para o ID informado");
        }

        /// <summary>
        /// Deleta um endereço existente
        /// </summary>
        /// <param name="id">ID do endereço que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Endereco/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Endereco enderecoBuscado = _enderecoRepository.BuscarPorId(id);

            if (enderecoBuscado != null)
            {
                try
                {
                    _enderecoRepository.Deletar(id);
                    return StatusCode(202);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }

            }

            return NotFound("Nenhum endereço encontrado para o ID informado");
        }
    }
}
