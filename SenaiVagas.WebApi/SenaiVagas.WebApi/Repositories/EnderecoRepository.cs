using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiVagas.WebApi.Domains;
using SenaiVagas.WebApi.Interfaces;

namespace SenaiVagas.WebApi.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        SenaiVagasContext ctx = new SenaiVagasContext();
        public void Atualizar(int id, Endereco enderecoAtualizado)
        {
            Endereco enderecoBuscado = ctx.Endereco.Find(id);

            enderecoBuscado.Cep = enderecoAtualizado.Cep;
  

            enderecoBuscado.Numero = enderecoAtualizado.Numero;

            ctx.Endereco.Update(enderecoBuscado);

            ctx.SaveChanges();
        }

        public Endereco BuscarPorId(int id)
        {
            return ctx.Endereco.FirstOrDefault(e => e.IdEndereco == id);
        }

        public void Cadastrar(Endereco novoEndereco)
        {
            ctx.Endereco.Add(novoEndereco);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Endereco.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Endereco> Listar()
        {
            return ctx.Endereco.ToList();
        }
    }
}
