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
    public class DadoCandidatoController : ControllerBase
    {
        private IDadoCandidatoRepository _dadoCandidatoRepository;

        public DadoCandidatoController()
        {
            _dadoCandidatoRepository = new DadoCandidatoRepository();
        }

        /// <summary>
        /// Retorna uma lista de DadoCandidatos Cadastrados
        /// </summary>
        [Authorize(Roles ="ADMINISTRADOR")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_dadoCandidatoRepository.Listar());
        }

        /// <summary>
        /// Busca o DadoCandidato pelo id informado
        /// </summary>
        /// <param name="id">Id do DadoCandidato que sera buscado</param>
        /// <returns></returns>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            var candidato = _dadoCandidatoRepository.BuscarPorId(id);

            if (candidato != null)
            {
                return Ok(candidato);
            }

            return NotFound("Candidato não encontrado");
        }

        /// <summary>
        /// Cadastra um novo DadoCandidato
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "TipoCarreira": "string",
        ///        "PretencaoSalarial" : "double",
        ///        "ModeloContratacao" : "CLT",
        ///        "OndeQuerTrabalhar" : "string",
        ///        "Curriculo" : "string",
        ///        "NomeCompleto" : "string",
        ///        "LinkLinkedin" : "string",
        ///        "LinkGit" : "string",
        ///        "LinkPortifolio" : "string",
        ///        "Foto" : "string",
        ///        }
        ///     
        ///</remarks>
        /// <param name="novoDadoCandidato">Objeto que sera cadastrado</param>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Cadastrar(DadoCandidato novoDadoCandidato)
        {
            try
            {
                _dadoCandidatoRepository.Cadastrar(novoDadoCandidato);

                return StatusCode(201, novoDadoCandidato);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Atualizado um novo DadoCandidato, podendo ser alterado uma ou todas as informações 
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "TipoCarreira": "string",
        ///        "PretencaoSalarial" : "double",
        ///        "OndeQuerTrabalhar" : "string",
        ///        "Curriculo" : "string",
        ///        "NomeCompleto" : "string",
        ///        "LinkLinkedin" : "string",
        ///        "LinkGit" : "string",
        ///        "LinkPortifolio" : "string",
        ///        "Foto" : "string",
        ///        }
        ///     
        ///</remarks>
        /// <param name="dadoCandidatoAtualizado">Objeto que sera Atualizado</param>
        /// <param name="id">Id do DadoCandidato</param>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,DadoCandidato dadoCandidatoAtualizado)
        {
            var candidato = _dadoCandidatoRepository.BuscarPorId(id);

            if (candidato != null)
            {
                _dadoCandidatoRepository.Atualizar(id,dadoCandidatoAtualizado);

                return Ok();
            }

            return NotFound("Candidato não encontrado");
        }

        /// <summary>
        /// Deleta um DadoCandidato pelo id informado
        /// </summary>
        /// <param name="id">Id que sera usado para encontrar o candidato certo a ser deletado</param>
        /// <returns></returns>
        [Authorize(Roles = "CANDIDATO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var dadoCandidato = _dadoCandidatoRepository.BuscarPorId(id);

            if (dadoCandidato == null)
            {
                return NotFound("candidato não existe");
            }

            _dadoCandidatoRepository.Deletar(id);

            return Ok();
        }
    }
}
