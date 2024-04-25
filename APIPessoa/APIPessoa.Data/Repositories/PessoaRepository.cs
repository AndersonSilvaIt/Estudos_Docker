using APIPessoa.Business.Interfaces;
using APIPessoa.Business.Models;

namespace APIPessoa.Data.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Contexto ctx) : base(ctx)
        {
        }
    }
}
