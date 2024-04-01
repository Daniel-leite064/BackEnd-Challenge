using System.Linq.Expressions;
using System.Text.Json;
using BackEnd.Domain.Entities;
using BackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace BackEnd.Infra.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{

    public readonly DbSet<TEntity> _dbSet;

    private readonly ILogger<TEntity> _logger;

    public RepositoryBase(PgContext appContext, ILogger<TEntity> logger)
    {
        _dbSet = appContext.Set<TEntity>();
        _logger = logger;
    }

    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();


        return await query.ToListAsync();

    }

    public async Task<string> AddAsync(TEntity entity)
    {
        try
        {
            if (entity is null) throw new Exception("Null Entity");

            return JsonConvert.SerializeObject(await _dbSet.AddAsync(entity));

        }
        catch (Exception e)
        {
            _logger.LogError("Error on Add: " + e.Message);
            return await Task.FromResult("Error on Add: " + e.Message);
        }


    }
    public async Task<string> Update(TEntity entity)
    {
        try
        {
            if (entity is null) throw new Exception("Null Entity");

            _dbSet.Update(entity);

            return await Task.FromResult("Updated Successfully");
        }
        catch (Exception e)
        {

            _logger.LogError("Error on update: " + e.Message);
            return await Task.FromResult("Error on update: " + e.Message);
        }


    }

    public async Task<string> Delete(TEntity entity)
    {
        try
        {
            if (entity is null) throw new Exception("Null Entity");

            _dbSet.Remove(entity);

            return await Task.FromResult("Removed Successfully");
        }
        catch (Exception e)
        {

            _logger.LogError("Error on Remove: " + e.Message);
            return await Task.FromResult("Error on Remove" + e.Message);

        }


    }

}
