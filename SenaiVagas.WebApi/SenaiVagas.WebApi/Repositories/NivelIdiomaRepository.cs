using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{


    public class NivelIdiomaRepository : INivelIdiomaRepository
    {

        SenaiVagasContext ctx = new SenaiVagasContext();
        public void Atualizar(NivelIdioma idiomaAtualizado, int id)
        {
            NivelIdioma NivelIdiomaBuscado = ctx.NivelIdioma.Find(id);

            NivelIdiomaBuscado.Titulo = idiomaAtualizado.Titulo;



            ctx.NivelIdioma.Update(NivelIdiomaBuscado);

            ctx.SaveChanges();
        }

        public NivelIdioma Buscar(int id)
        {
            return ctx.NivelIdioma.FirstOrDefault(e => e.IdNivelIdioma == id);
        }

        public void Cadastrar(NivelIdioma NovoNivelIdioma)
        {
            ctx.NivelIdioma.Add(NovoNivelIdioma);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.NivelIdioma.Remove(Buscar(id));
            ctx.SaveChanges();
        }

        public List<NivelIdioma> ListarIdiomas()
        {
            return ctx.NivelIdioma.ToList();
        }
    }
}