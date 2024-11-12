using System.Linq.Expressions;
using JobSite.Application.Common.Exceptions;
using JobSite.Domain.Common;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;

namespace JobSite.Infrastructure.Common.BaseRepository;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;
    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    //Expression<Func<TEntity, bool>> predicate: a expression that represents a lambda function that takes a TEntity and returns a bool

    //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort: a function that takes a IQueryable<TEntity> 
    //and returns a IOrderedQueryable<TEntity>

    //IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes: a collection of expressions that represents a lambda function that takes  
    //a TEntity and returns a BaseEntity 

    //Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>> includeQuery: a function that takes a IQueryable<TEntity>
    //and returns a IIncludableQueryable<TEntity, object>

    public IQueryable<TEntity> GetQuery() => this._dbSet;

    public async Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var entity = await _dbSet.Where(predicate).FirstOrDefaultAsync(cancellationToken);
        return entity ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }
    public async Task<TEntity> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }

    public async Task<TEntity> GetByIdAsync(
        Guid id,
        IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        var entity = await query.SingleAsync(x => x.Id == id, cancellationToken);
        return entity ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }

    public Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate,
        IEnumerable<Expression<Func<TEntity, object>>> includes,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query.SingleAsync(cancellationToken) ?? throw new BadRequestException($"not found {nameof(TEntity)}");
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).FirstOrDefaultAsync(cancellationToken) ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<Expression<Func<TEntity,
        BaseEntity>>> includes,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(cancellationToken) ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>> includeQuery,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        query = includeQuery(query);
        return await query.FirstOrDefaultAsync(cancellationToken) ?? throw new BadRequestException($"not found {nameof(TEntity)}"); ;
    }

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        IEnumerable<Expression<Func<TEntity,
        BaseEntity>>> includes,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>> includeQuery,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        query = includeQuery(query);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>,
        IOrderedQueryable<TEntity>> sort,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        query = sort(query);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
        IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        query = sort(query);
        return await query.ToListAsync(cancellationToken);
    }

    // public async Task<PaginationResponse<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate,
    //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort, int pageIndex, int pageSize)
    // {
    //     var query = sort(_dbSet.Where(predicate));

    //     return await this.GetPaginationEntities(query, pageIndex, pageSize);
    // }

    // public async Task<PaginationResponse<TEntity>> GetAllAsync(
    //     Expression<Func<TEntity, bool>> predicate,
    //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
    //     int pageIndex,
    //     int pageSize,
    //     IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes)
    // {
    //     var query = _dbSet.Where(predicate);

    //     foreach (var include in includes)
    //     {
    //         query = query.Include(include);
    //     }

    //     query = sort(query);

    //     return await this.GetPaginationEntities(query, pageIndex, pageSize);
    // }

    // public async Task<PaginationResponse<TEntity>> GetAllAsync(
    //     Expression<Func<TEntity, bool>> predicate,
    //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
    //     int pageIndex,
    //     int pageSize,
    //     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeQuery)
    // {
    //     var query = _dbSet.Where(predicate);

    //     query = includeQuery(query);

    //     query = sort(query);

    //     return await this.GetPaginationEntities(query, pageIndex, pageSize);
    // }

    public async Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken)
    {
        var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return addedEntity;
    }

    public async Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken)
    {
        var removedEntity = _dbSet.Remove(entity).Entity;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return removedEntity;
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<TEntity>> UpdateRangeAsync(
        List<TEntity> entities,
        CancellationToken cancellationToken)
    {
        _dbSet.UpdateRange(entities);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    // protected async Task<PaginationResponse<TEntity>> GetPaginationEntities(IQueryable<TEntity> query, int pageIndex, int pageSize)
    // {
    //     var totalItems = await query.CountAsync();

    //     var response = new PaginationResponse<TEntity>
    //     {
    //         PageIndex = pageIndex,
    //         PageSize = pageSize,
    //         TotalCount = totalItems,
    //         Items = Enumerable.Empty<TEntity>()
    //     };

    //     if (totalItems > 0)
    //     {
    //         response.Items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    //     }

    //     return response;
    // }
}
