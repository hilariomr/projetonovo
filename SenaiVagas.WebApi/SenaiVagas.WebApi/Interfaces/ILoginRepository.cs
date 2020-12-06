using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Interfaces
{
    interface ILoginRepository
    {
        // Metodo recebe Email/CPF e senha 
        Candidato LoginDeCandidato(LoginViewModel login);

        Empresa LoginDeEmpresa(LoginViewModel login);

        Administrador LoginDeAdm(LoginViewModel login);

    }
}
