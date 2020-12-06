using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class IdiomaRepository : IidiomaRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();
        public List<Idioma> Listar()
        {
            return ctx.Idioma.ToList();
        }


        public void Cadastrar(Idioma idioma)
        {
            ctx.Idioma.Add(idioma);
            ctx.SaveChanges();
        }

        public void Atualizar(Idioma idiomaAtualizado, int id)
        {
            Idioma idiomaBuscado = ctx.Idioma.Find(id);

            idiomaBuscado.Titulo = idiomaAtualizado.Titulo;



            ctx.Idioma.Update(idiomaBuscado);

            ctx.SaveChanges();

        }

        public Idioma Buscar(int id)
        {
            // Retorna o primeiro idioma encontrado para o ID informado

            return ctx.Idioma.FirstOrDefault(e => e.IdIdioma == id);
        }

        public void Deletar(int id)
        {
            ctx.Idioma.Remove(Buscar(id));
            ctx.SaveChanges();
        }


    }
}