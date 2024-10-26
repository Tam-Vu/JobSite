using System.Linq.Expressions;
using JobSite.Application.Common.Exceptions;
using JobSite.Domain.Common;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore.Query;

namespace JobSite.Infrastructure.Accounts.Persistence;
public class AccountRepository : IAccountRepository
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<Account> _dbSet;
    public AccountRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Account>();
    }
    public async Task<Account> AddAsync(Account entity, CancellationToken cancellationToken)
    {
        var addedEntity = (await _dbContext.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return addedEntity;
    }

    public async Task<Account> DeleteAsync(Account entity, CancellationToken cancellationToken)
    {
        var removedEntity = _dbContext.Remove(entity).Entity;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return removedEntity;
    }

    public async Task<List<Account>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, IEnumerable<Expression<Func<Account, BaseEntity>>> includes, CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, Func<IQueryable<Account>, IIncludableQueryable<Account, object>> includeQuery, CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        query = includeQuery(query);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, Func<IQueryable<Account>, IOrderedQueryable<Account>> sort, CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        query = sort(query);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Account> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity ?? throw new NotFoundException($"not found {nameof(Account)}");
    }

    public IQueryable<Account> GetQuery() => this._dbSet;
    public async Task<Account> GetSingleOrDefaultAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).SingleOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"not found {nameof(Account)}");

    }

    public async Task<Account> GetSingleOrDefaultAsync(Expression<Func<Account, bool>> predicate, IEnumerable<Expression<Func<Account, BaseEntity>>> includes, CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.SingleOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"not found {nameof(Account)}");
    }

    public async Task<Account> UpdateAsync(Account entity, CancellationToken cancellationToken)
    {
        var updatedEntity = _dbContext.Update(entity).Entity;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return updatedEntity;
    }
}