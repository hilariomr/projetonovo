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
    [Authorize]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private IInscricaoRepository _inscricaoRepository;

        public InscricaoController()
        {
            _inscricaoRepository = new InscricaoRepository();
        }


        /// <summary>
        /// Lista todas as Inscrições
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_inscricaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma Inscrição através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var insc = _inscricaoRepository.BuscarPorId(id); 

            if(insc == null)
            {
                return NotFound("Inscrição não encontrada");
            }

            return Ok(insc);
        }

        /// <summary>
        /// Busca todas as Inscrições que a vaga possui
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma lista de inscrições relacionados ao id da vaga</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("InscricoesVaga/{id}")]
        public IActionResult BuscarIncricoesDaVaga(int id)
        {
           var inscricao = _inscricaoRepository.BuscarIncricoesDaVaga(id);

            if(inscricao == null)
            {
                return NotFound("Vaga sem inscrições");
            }
            return Ok(inscricao);
        }

        /// <summary>
        /// Busca todas as Inscrições que o candidato possui
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma lista de inscrições relacionados ao id do candidato</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("InscricoesCandidato/{id}")]
        public IActionResult BuscarIncricoesDoCandidato(int id)
        {
            var inscricao = _inscricaoRepository.BuscarIncricoesDoCandidato(id);

            if (inscricao == null)
            {
                return NotFound("Candidato sem inscrições");
            }
            return Ok(inscricao);
        }

        /// <summary>
        /// Cadastra uma nova Inscrição
        /// </summary>
        /// Sample response:
        /// 
        ///      {
        ///        "IdCandidato": 1,
        ///        "IdVaga" : 1   
        ///      }
        /// 
        /// <param name="novoInscricao"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post(Inscricao novoInscricao)
        {
           try
            {
                _inscricaoRepository.Cadastrar(novoInscricao);

                return StatusCode(201);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deleta uma Inscrição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "EMPRESA")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var insc = _inscricaoRepository.BuscarPorId(id);

            if (insc == null)
            {
                return NotFound("Inscrição não encontrada");
            }

            _inscricaoRepository.Deletar(id);

            return Ok();
        }

    }
}
