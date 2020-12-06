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
    /// Controller responsável pelos endpoints referentes as Formacões
    /// </summary>
    /// 
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FormacaoController : ControllerBase
    {
        private IFormacaoRepository _formacaoRepository;

        public FormacaoController()
        {
            _formacaoRepository = new FormacaoRepository();
        }


        /// <summary>
        /// Lista todas as Formações
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_formacaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma Formação através do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_formacaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Formação
        /// </summary>
        /// <param name="novoFormação"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Formacao novoFormacao)
        {
            _formacaoRepository.Cadastrar(novoFormacao);
            return StatusCode(200);
        }

        /// <summary>
        /// Deleta uma Formação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _formacaoRepository.Deletar(id);
            return StatusCode(200);
        }

        /// <summary>
        /// Atualiza uma Formação existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formacao"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Formacao formacao)
        {
            _formacaoRepository.Atualizar(id, formacao);
            return StatusCode(200);
        }


    }
}
