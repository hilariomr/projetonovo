using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        SenaiVagasContext ctx = new SenaiVagasContext();

        public Administrador LoginDeAdm(LoginViewModel login)
        {
            return ctx.Administrador.FirstOrDefault(e => e.Email == login.Email && e.Senha == login.Senha);
        }

        public Candidato LoginDeCandidato(LoginViewModel login)
        {

            if((login.Email != null) && (login.Email != ""))
            {
                return ctx.Candidato.FirstOrDefault(e => e.Email == login.Email && e.Senha == login.Senha);
            }else
            {
                return ctx.Candidato.FirstOrDefault(e => e.Cpf == login.Cpf && e.Senha == login.Senha);
            }

        }

        public Empresa LoginDeEmpresa(LoginViewModel login)
        {
            if ((login.Email != null) && (login.Email != ""))
            {
                return ctx.Empresa.FirstOrDefault(e => e.Email == login.Email && e.Senha == login.Senha);
            }

            return ctx.Empresa.FirstOrDefault(e => e.Cnpj == login.Cnpj && e.Senha == login.Senha);
        }
    }
}
