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
    public class NivelIdiomaController : ControllerBase
    {

        private INivelIdiomaRepository _nivelIdiomaIdiomasRepository;
        public NivelIdiomaController()
        {
            _nivelIdiomaIdiomasRepository = new NivelIdiomaRepository();
        }


        /// <summary>
        /// retorna uma lista de nivel de idioma
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_nivelIdiomaIdiomasRepository.ListarIdiomas());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_nivelIdiomaIdiomasRepository.Buscar(id));
        }





    }
}