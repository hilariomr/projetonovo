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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {

        private ICandidatoRepository _candidatoRepository;

        public CandidatoController()
        {
            _candidatoRepository = new CandidatoRepository();
        }

        /// <summary>
        /// Retorna uma lista de Candidatos Cadastrados
        /// </summary>
        [Authorize(Roles = "ADMINISTRADOR")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Listar()
        {
             return Ok(_candidatoRepository.Listar());
            
        }


        /// <summary>
        /// Busca o candidato pelo id informado
        /// </summary>
        /// <param name="id">Id do candidato que sera buscado</param>
        /// <returns></returns>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            var candidato = _candidatoRepository.BuscarPorId(id);

            if(candidato != null)
            {
                return Ok(candidato);
            }

            return NotFound("Candidato não encontrado");
        }

        /// <summary>
        /// Cadastra um novo candidato
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Email": "email@email.com",
        ///        "cpf" : "123456789101",
        ///        "Senha" : "****"
        ///        "IdDadoCandidato" : 1
        ///        }
        ///     
        ///</remarks>
        /// <param name="novoCandidato">Objeto que sera cadastrado</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Cadastrar(Candidato novoCandidato)
        {
            try
            {
                _candidatoRepository.Cadastrar(novoCandidato);

                return StatusCode(201, novoCandidato);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Atualiza um candidato podendo ser alterado uma ou todas as informações 
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Email": "email@email.com",
        ///        "cpf" : "123456789101",
        ///        "Senha" : "****"
        ///        }
        ///     
        ///</remarks>
        /// <param name="candidatoAtualizado">Objeto que sera cadastrado</param>
        /// <param name="id">Id do Candidato</param>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id , Candidato candidatoAtualizado)
        {
            var candidato = _candidatoRepository.BuscarPorId(id);

            if(candidato != null)
            {
                _candidatoRepository.Atualizar(id,candidatoAtualizado);

                return Ok();
            }

            return NotFound("Candidato não encontrado");
        }

        /// <summary>
        /// Deleta um candidato pelo id informado
        /// </summary>
        /// <param name="id">Id que sera usado para encontrar o candidato certo a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles ="CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var candidato = _candidatoRepository.BuscarPorId(id);

            if (candidato == null)
            {
                return NotFound("candidato não encontrado");
            }

            _candidatoRepository.Deletar(id);

            return Ok();
        }
    }
}
