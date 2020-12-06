using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Senha { get; set; }
        public uint TipoUsuario { get; set; }
    }
}
