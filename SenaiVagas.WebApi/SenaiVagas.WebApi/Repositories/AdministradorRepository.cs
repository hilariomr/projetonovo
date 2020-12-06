using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;

namespace SenaiVagas.WebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();
        public void Atualizar(int id, Administrador adminAtualizado)
        {
            Administrador adminBuscado = ctx.Administrador.Find(id);

            adminBuscado.NomeAdm = adminAtualizado.NomeAdm;

            adminBuscado.Email = adminAtualizado.Email;

            adminBuscado.Senha = adminAtualizado.Senha;

            ctx.Administrador.Update(adminBuscado);

            ctx.SaveChanges();

        }

        public Administrador BuscarPorId(int id)
        {
            return ctx.Administrador.FirstOrDefault(a => a.IdAdministrador == id);
        }

        public void Cadastrar(Administrador novoAdmin)
        {
            ctx.Administrador.Add(novoAdmin);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Administrador.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Administrador> Listar()
        {
            return ctx.Administrador.ToList();
        }
    }
}
