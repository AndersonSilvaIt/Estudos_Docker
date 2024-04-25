using API_Pessoa.ViewModels;
using APIPessoa.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Pessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public ActionResult<List<PessoaVM>> Obter()
        {
            List<PessoaVM> listPessoa = new List<PessoaVM>
            {
                new PessoaVM{ Id = 1, Nome = "Pessoa 1", Idade = 15 },
                new PessoaVM{ Id = 2, Nome = "Pessoa 2", Idade = 18 },
                new PessoaVM{ Id = 3, Nome = "Pessoa 3", Idade = 25 }
            };

            return Ok(listPessoa);
        }

        [HttpGet("{id}")]
        public ActionResult<PessoaVM> ObterPorId(int id)
        {
            var pessoa = new PessoaVM
            {
                Id = 1,
                Nome = "Pessoa 1",
                Idade = 15
            };

            return Ok(pessoa);
        }
    }
}
