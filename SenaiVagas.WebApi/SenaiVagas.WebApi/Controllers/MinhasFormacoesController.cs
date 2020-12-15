using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.Repositories;

namespace SenaiVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MinhasFormacoesController : ControllerBase
    {
        private IMinhasFormacoesRepository _minhasFormacoesRepository;

        public MinhasFormacoesController()
        {
            _minhasFormacoesRepository = new MinhasFormacoesRepository();
        }

        /// <summary>
        /// Lista todas as Minhas Formações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_minhasFormacoesRepository.Listar());
        }

        /// <summary>
        /// Busca uma Formação através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_minhasFormacoesRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Busca uma Formação através do DadoCandidato id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("dadocandidato/{id}")]
        public IActionResult GetByDadoCandidatoId(int id)
        {
            return Ok(_minhasFormacoesRepository.BuscarPorIdDadoCandidato(id));
        }
    }
}
