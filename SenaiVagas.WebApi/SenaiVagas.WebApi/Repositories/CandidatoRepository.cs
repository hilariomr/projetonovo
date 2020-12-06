using Microsoft.EntityFrameworkCore;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using SenaiVagas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {

        SenaiVagasContext ctx = new SenaiVagasContext();



        public void Atualizar(int id,Candidato CandidatoAtlz)
        {
            Candidato candidatoBuscado = BuscarPorId(id);

            if (CandidatoAtlz.Email != null)
            {
                if (CandidatoAtlz.Email == "")
                {
                    CandidatoAtlz.Email = candidatoBuscado.Email;
                }
                candidatoBuscado.Email = CandidatoAtlz.Email;
            }
            if (CandidatoAtlz.Cpf!= null)
            {
                if (CandidatoAtlz.Cpf == "")
                {
                    CandidatoAtlz.Cpf = candidatoBuscado.Cpf;
                }
                candidatoBuscado.Cpf = CandidatoAtlz.Cpf;
            }
            if (CandidatoAtlz.Senha != null)
            {
                if(CandidatoAtlz.Senha == "")
                {
                    CandidatoAtlz.Senha = candidatoBuscado.Senha;
                }
                candidatoBuscado.Senha = CandidatoAtlz.Senha;
            }
            ctx.Candidato.Update(candidatoBuscado);
            ctx.SaveChanges();
        }

        public Candidato BuscarPorId(int id)
        {
            var candidato = ctx.Candidato.Include(c => c.IdDadoCandidatoNavigation).FirstOrDefault(e => e.IdCandidato == id);
            return candidato;
        }

        public void Cadastrar(Candidato NovoCandidato)
        {
            ctx.Candidato.Add(NovoCandidato);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            var candidato = ctx.Candidato.FirstOrDefault(c => c.IdCandidato == id);
            ctx.Candidato.Remove(candidato);
            ctx.SaveChanges();
        }

        public List<Candidato> Listar()
        {
            var candidato = ctx.Candidato.ToList();
            

            // candidato.ForEach(c => c.IdDadoCandidatoNavigation = _dadoCandidatoRepository.BuscarPorId(c.IdDadoCandidato));
            // candidato.ForEach(c => c.Inscricao = _inscricaoRepository.Listar().Where(i => i.IdCandidato == c.IdCandidato).ToList());

            return candidato;
        }
    }
}
