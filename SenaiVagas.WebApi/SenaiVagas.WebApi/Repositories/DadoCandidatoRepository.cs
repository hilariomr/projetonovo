using Microsoft.EntityFrameworkCore;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiVagas.WebApi.Repositories
{
    public class DadoCandidatoRepository : IDadoCandidatoRepository
    {

        // private IMeusIdiomasRepository _meusIdiomasRepository { get; set; }
        // private IMeusIdiomasRepository _minhasFormacoesRepository { get; set; }
        private ICandidatoRepository _candidatoRepository { get; set; }

        public DadoCandidatoRepository()
        {
            // _meusIdiomasRepository = new MeusIdiomasRepository();
            _candidatoRepository = new CandidatoRepository();
        }

        SenaiVagasContext ctx = new SenaiVagasContext();

        public void Atualizar(int id, DadoCandidato DadoCandidatoAtlz)
        {
            DadoCandidato dadoCandidatoBuscado = BuscarPorId(id);

            if (DadoCandidatoAtlz.TipoCarreira != null)
            {
                if (DadoCandidatoAtlz.TipoCarreira == "")
                {
                    DadoCandidatoAtlz.TipoCarreira = dadoCandidatoBuscado.TipoCarreira;
                } else
                {
                    dadoCandidatoBuscado.TipoCarreira = DadoCandidatoAtlz.TipoCarreira;
                }
            }
            if (DadoCandidatoAtlz.PretencaoSalarial != 0.0)
            {
                dadoCandidatoBuscado.PretencaoSalarial = DadoCandidatoAtlz.PretencaoSalarial;
            }
            if (DadoCandidatoAtlz.ModeloContratacao != null)
            {
                if (DadoCandidatoAtlz.ModeloContratacao == "")
                {
                    DadoCandidatoAtlz.ModeloContratacao = dadoCandidatoBuscado.ModeloContratacao;
                }
                else
                {
                    dadoCandidatoBuscado.ModeloContratacao = DadoCandidatoAtlz.ModeloContratacao;
                }

            }
            
            if (DadoCandidatoAtlz.Curriculo != null)
                {
                    if (DadoCandidatoAtlz.Curriculo == "")
                    {
                        DadoCandidatoAtlz.Curriculo = dadoCandidatoBuscado.Curriculo;
                    }
                    else
                    {
                        dadoCandidatoBuscado.Curriculo = DadoCandidatoAtlz.Curriculo;

                    }

                }
            if (DadoCandidatoAtlz.NomeCompleto != null)
            {
                    if (DadoCandidatoAtlz.NomeCompleto == "")
                    {
                        DadoCandidatoAtlz.Curriculo = dadoCandidatoBuscado.Curriculo;
                    }
                    else
                    {
                        dadoCandidatoBuscado.NomeCompleto = DadoCandidatoAtlz.NomeCompleto;

                    }

            }
            if (DadoCandidatoAtlz.LinkLinkedin != null)
            {
                if (DadoCandidatoAtlz.LinkLinkedin == "")
                {
                    DadoCandidatoAtlz.LinkLinkedin = dadoCandidatoBuscado.LinkLinkedin;
                }
                else
                {
                    dadoCandidatoBuscado.LinkLinkedin = DadoCandidatoAtlz.LinkLinkedin;

                }
            }
            if (DadoCandidatoAtlz.LinkGit != null)
            {
                if (DadoCandidatoAtlz.LinkGit == "")
                {
                    DadoCandidatoAtlz.LinkGit = dadoCandidatoBuscado.LinkGit;
                }
                else
                {
                    dadoCandidatoBuscado.LinkGit = DadoCandidatoAtlz.LinkGit;

                }
                
            }
            if (DadoCandidatoAtlz.LinkPortifolio != null)
            {
                if (DadoCandidatoAtlz.LinkPortifolio == "")
                {
                    DadoCandidatoAtlz.LinkPortifolio = dadoCandidatoBuscado.LinkPortifolio;
                }
                else
                {
                    dadoCandidatoBuscado.LinkPortifolio = DadoCandidatoAtlz.LinkPortifolio;

                }
                
            }
            if (DadoCandidatoAtlz.Foto != null)
            {
                if (DadoCandidatoAtlz.Foto == "")
                {
                    DadoCandidatoAtlz.Foto = dadoCandidatoBuscado.Foto;
                }
                else
                {
                    dadoCandidatoBuscado.Foto = DadoCandidatoAtlz.Foto;

                }
                
            }
            if (DadoCandidatoAtlz.IdEndereco != null)
            {
                if (DadoCandidatoAtlz.IdEndereco == 0)
                {
                    DadoCandidatoAtlz.IdEndereco = dadoCandidatoBuscado.IdEndereco;
                }
                else
                {
                    dadoCandidatoBuscado.IdEndereco = DadoCandidatoAtlz.IdEndereco;

                }
                
            }

            ctx.DadoCandidato.Update(dadoCandidatoBuscado);
            ctx.SaveChanges();
            

        }
        public DadoCandidato BuscarPorId(int id)
        {
            var dadoCandidato = ctx.DadoCandidato.Include(d => d.Candidato).Include(d => d.MeusIdiomas).Include(d => d.MinhasFormacoes).FirstOrDefault(d => d.IdDadoCandidato == id);

            
            return dadoCandidato;
        }

        public void Cadastrar(DadoCandidato NovoDadoCandidato)
        {
            ctx.DadoCandidato.Add(NovoDadoCandidato);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            var dadoCandidato = ctx.DadoCandidato.FirstOrDefault(d => d.IdDadoCandidato == id);
            ctx.DadoCandidato.Remove(dadoCandidato);
            ctx.SaveChanges();
        }

        public List<DadoCandidato> Listar()
        {
            var dadoCandidato = ctx.DadoCandidato.ToList();

            // dadoCandidato.ForEach(c => c.MeusIdiomas = _meusIdiomasRepository.Listar().Where(i => i.IdDadoCandidato == c.IdDadoCandidato).ToList());
            // dadoCandidato.ForEach(c => c.MinhasFormacoes = _minhasFormacoesRepository.Listar().Where(f => f.IdDadoCandidato == c.IdDadoCandidato).ToList());
            dadoCandidato.ForEach(c => c.Candidato = _candidatoRepository.Listar().Where(i => i.IdDadoCandidato == c.IdDadoCandidato).ToList());

            return dadoCandidato;
        }
    }
}

