using System.Linq.Expressions;
using BackEnd.Domain.Entities;

namespace BackEnd.Infra.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null);
    
    Task<string> AddAsync(TEntity entity);

    Task<string> Update(TEntity entity);

    Task<string> Delete(TEntity entity);


}
