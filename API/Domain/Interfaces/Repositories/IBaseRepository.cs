using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{

    public interface IBaseRepository<TEntity, TId> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> GetAllWithIncludes(params string[] includes);
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> query);
        Task<IQueryable<TEntity>> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes);
        Task<TEntity> GetById(TId id);
        Task<TEntity> Insert(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<int> SaveChanges();
    }
}
