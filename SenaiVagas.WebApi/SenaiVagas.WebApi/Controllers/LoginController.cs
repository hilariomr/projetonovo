using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaiVagas.WebApi.Enums;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.Repositories;
using SenaiVagas.WebApi.ViewModels;

namespace SenaiVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginRepository _loginRepository;

        public LoginController()
        {
            _loginRepository = new LoginRepository();
        }

        /// <summary>
        /// Metodo que gera um token para logar o usuario
        /// </summary>
        ///  <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Email": "email@email.com",
        ///        "cpf" : "123456789101",
        ///        "cnpj" : "12345678910111",
        ///        "Senha" : "****"
        ///        "TipoUsuario": 0,
        ///        }
        ///     
        ///</remarks>
        /// <param name="login">login o objeto que vem com o email/cpf/cnpj é senha do usuario</param>
        /// <returns>Retorna o token gerado</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            IEnumerable<System.Security.Claims.Claim> claims = null;
            int idUsuario = 0;

            switch(login.TipoUsuario)
            {
                case (uint) TipoUsuario.ADMINISTRADOR:

                    if ((login.Email == null) || (login.Senha == null))
                    {
                        return BadRequest("Email ou Senha nulos");
                    }

                    var adm = _loginRepository.LoginDeAdm(login);

                    if (adm == null)
                    {
                        return NotFound("Adm não encontrado");
                    }

                    idUsuario = adm.IdAdministrador;
                    claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, adm.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, adm.IdAdministrador.ToString()),
                        new Claim(ClaimTypes.Role, TipoUsuario.ADMINISTRADOR.ToString()),
                        new Claim("role", TipoUsuario.ADMINISTRADOR.ToString())
                     };
                    break;
                case (uint)TipoUsuario.CANDIDATO:

                    if ((login.Email == null) && (login.Cpf == null))
                    {
                        return BadRequest("Email ou Cpf nulos");                        
                    }
                    
                    if (login.Senha == null)
                    {
                        return BadRequest("Senha nula");
                    }

                    var candidato = _loginRepository.LoginDeCandidato(login);

                    if (candidato == null)
                    {
                        return NotFound("Candidato não encontrado");
                    }

                    idUsuario = candidato.IdCandidato;
                    claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, candidato.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, candidato.IdCandidato.ToString()),
                        new Claim(ClaimTypes.Role, TipoUsuario.CANDIDATO.ToString()),
                        new Claim("role", TipoUsuario.CANDIDATO.ToString())
                     };
                    break;
                case (uint)TipoUsuario.EMPRESA:

                    if ((login.Email == null) && (login.Cnpj == null))
                    {
                        return BadRequest("Email ou Cnpj nulos");
                    }

                    if (login.Senha == null)
                    {
                        return BadRequest("Senha nula");
                    }

                    var empresa = _loginRepository.LoginDeEmpresa(login);

                    if (empresa == null)
                    {
                        return NotFound("Empresa não encontrado");
                    }

                    idUsuario = (int) empresa.IdEmpresa;
                    claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, empresa.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, empresa.IdEmpresa.ToString()),
                        new Claim(ClaimTypes.Role, TipoUsuario.EMPRESA.ToString()),
                        new Claim("role", TipoUsuario.EMPRESA.ToString())
                     };
                    break;
                default:
                    return NotFound("Tipo de Usuario não encontrado");

            }

           

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senaivagas-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "SenaiVagas.WebApi",                // emissor do token
                audience: "SenaiVagas.WebApi",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                idUsuario,
                tipoUsuario = login.TipoUsuario
            });


                

        }
    }
}
