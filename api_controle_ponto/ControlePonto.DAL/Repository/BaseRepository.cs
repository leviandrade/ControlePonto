using ControlePonto.DAL.Interfaces;
using ControlePonto.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControlePonto.DAL.Repository
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
       where TEntity : BaseEntity
       where TContext : DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(TContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> Listar()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task Remover(int id)
        {
            DbSet.Remove(await ObterPorId(id));
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
