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
    [ApiController]
    public class MeusIdiomasController : ControllerBase
    {
        private IMeusIdiomasRepository _meusIdiomasRepository;
        public MeusIdiomasController()
        {
            _meusIdiomasRepository = new MeusIdiomasRepository();
        }

        /// <summary>
        /// retorna a lista dos "meus idiomas"
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_meusIdiomasRepository.ListarIdiomas());
        }





    }


}