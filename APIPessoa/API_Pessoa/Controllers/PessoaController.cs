using API_Pessoa.ViewModels;
using APIPessoa.Business.Interfaces;
using APIPessoa.Business.Models;
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
        public async Task<ActionResult<List<PessoaVM>>> Obter()
        {
            var list = await _pessoaRepository.Listar();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaVM>> ObterPorId(int id)
        {
            var pessoa = await _pessoaRepository.ObterPorId(id);

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Adicionar(Pessoa pessoa)
        {
            var pessoaAdd = await _pessoaRepository.Adicionar(pessoa);

            return Ok(pessoaAdd);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Atualizar(Pessoa pessoa)
        {
            var update = await _pessoaRepository.Atualizar(pessoa);

            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            var update = await _pessoaRepository.Remover(id);

            return Ok(update);
        }

    }
}
