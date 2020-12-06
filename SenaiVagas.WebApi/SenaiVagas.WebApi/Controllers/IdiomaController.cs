using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class IdiomaController : ControllerBase
    {
        private IidiomaRepository _idiomaRepository;

        public IdiomaController()
        {
            _idiomaRepository = new IdiomaRepository();
        }

        /// <summary>
        /// Retorna uma lista de idiomas 
        /// </summary>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_idiomaRepository.Listar());
        }

        /// <summary>
        /// cadastra um idioma
        /// </summary>

        [HttpPost]
        public IActionResult Post(Idioma idioma)
        {
            _idiomaRepository.Cadastrar(idioma);

            return StatusCode(201);
        }


        /// <summary>
        ///atualiza um idioma
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Idioma idiomaAtualizado)
        {
            Idioma idiomaBuscado = _idiomaRepository.Buscar(id);
            _idiomaRepository.Atualizar(idiomaAtualizado, id);

            return StatusCode(204);
        }
        /// <summary>
        /// busca o idioma pelo id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(200, _idiomaRepository.Buscar(id));
        }

        /// <summary>
        /// Deleta o idioma
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _idiomaRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}