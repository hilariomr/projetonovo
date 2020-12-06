using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.Repositories;

namespace SenaiVagas.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos Administradores
    /// </summary>

    [Authorize(Roles ="ADMINISTRADOR")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _administradorRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IAdministradorRepository _administradorRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public AdministradorController()
        {
            _administradorRepository = new AdministradorRepository();
        }

        /// <summary>
        /// Lista todos os administradores
        /// </summary>
        /// <returns>Uma lista de administradores e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de administradores</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Administrador
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_administradorRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Busca um administrador através do ID
        /// </summary>
        /// <param name="id">ID do administrador que será buscado</param>
        /// <returns>Um administrador buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o administrador buscado</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Administrador/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(200, _administradorRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Cadastra um novo administrador
        /// </summary>
        /// <param name="novoAdmin">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Administrador
        [HttpPost]
        public IActionResult Post(Administrador novoAdmin)
        {
            try
            {
                _administradorRepository.Cadastrar(novoAdmin);
                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        /// <summary>
        /// Atualiza um administrador existente
        /// </summary>
        /// <param name="id">ID do administrador que será atualizado</param>
        /// <param name="adminAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Administrador/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador adminAtualizado)
        {
            Administrador adminBuscado = _administradorRepository.BuscarPorId(id);
            if (adminBuscado != null)
            {
                try
                {
                    _administradorRepository.Atualizar(id, adminAtualizado);

                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }
            }
            return NotFound("Nenhum administrador encontrado para o ID informado");
        }

        /// <summary>
        /// Deleta um administrador existente
        /// </summary>
        /// <param name="id">ID do administrador que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Administrador/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Administrador adminBuscado = _administradorRepository.BuscarPorId(id);

            if (adminBuscado != null)
            {
                try
                {
                    _administradorRepository.Deletar(id);
                    return StatusCode(202);
                }
                catch (Exception error)
                {

                    BadRequest(error);
                }
            }
            return NotFound("Nenhum administrador encontrado para o ID informado");
        }
    }
}
