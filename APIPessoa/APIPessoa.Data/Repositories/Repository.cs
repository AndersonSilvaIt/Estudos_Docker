using APIPessoa.Business.Interfaces;
using APIPessoa.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPessoa.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase, new()
    {
        private Contexto _db;
        private DbSet<T> DBSet;

        public Repository(Contexto ctx)
        {
            _db = ctx;
            DBSet = _db.Set<T>();
        }

        public async Task<List<T>> Listar()
        {
            return await DBSet.ToListAsync();
        }

        public async Task<T> ObterPorId(int id)
        {
            return await DBSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> Adicionar(T entity)
        {
            DBSet.Add(entity);

            await SaveChanges();

            return entity;
        }

        public async Task<bool> Atualizar(T entity)
        {
            DBSet.Update(entity);

            return (await SaveChanges()) > 0;
        }

        public async Task<bool> Remover(int id)
        {
            var item = new T { Id = id };
            DBSet.Remove(item);

            return (await SaveChanges()) > 0;
        }

        private async Task<int> SaveChanges()
        {
            int qtd = 0;

            try
            {
                qtd = await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return qtd;
        }
    }
}
