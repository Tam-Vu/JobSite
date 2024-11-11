
using System.Linq.Expressions;
using JobSite.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace JobSite.Application.IRepository;
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    //Expression<Func<TEntity, bool>> predicate: a expression that represents a lambda function that takes a TEntity and returns a bool

    //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort: a function that takes a IQueryable<TEntity> 
    //and returns a IOrderedQueryable<TEntity>

    //IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes: a collection of expressions that represents a lambda function that takes  
    //a TEntity and returns a BaseEntity 

    //Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>> includeQuery: a function that takes a IQueryable<TEntity>
    //and returns a IIncludableQueryable<TEntity, object>

    IQueryable<TEntity> GetQuery();
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(Guid id, IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes, CancellationToken cancellationToken);

    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity,
        BaseEntity>>> includes, CancellationToken cancellationToken);

    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>> includeQuery, CancellationToken cancellationToken);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<Expression<Func<TEntity,
        BaseEntity>>> includes, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>> includeQuery, CancellationToken cancellationToken);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
    IOrderedQueryable<TEntity>> sort, CancellationToken cancellationToken);

    Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
        IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes,
        CancellationToken cancellationToken);

    // Task<PaginationResponse<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate,
    //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort, int pageIndex, int pageSize);

    // Task<PaginationResponse<TEntity>> GetAllAsync(
    //     Expression<Func<TEntity, bool>> predicate,
    //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
    //     int pageIndex,
    //     int pageSize,
    //     IEnumerable<Expression<Func<TEntity, BaseEntity>>> includes);

    // Task<PaginationResponse<TEntity>> GetAllAsync(
    //    Expression<Func<TEntity, bool>> predicate,
    //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort,
    //    int pageIndex,
    //    int pageSize,
    //    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeQuery);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}