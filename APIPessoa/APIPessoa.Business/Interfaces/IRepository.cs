using APIPessoa.Business.Models;

namespace APIPessoa.Business.Interfaces
{
    public interface IRepository<T> where T : EntityBase, new()
    {
        Task<List<T>> Listar();
        Task<T> ObterPorId(int id);
        Task<T> Adicionar(T entity);
        Task<bool> Atualizar(T entity);
        Task<bool> Remover(int id);
    }
}