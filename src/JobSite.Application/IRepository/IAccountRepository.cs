using System.Linq.Expressions;
using JobSite.Domain.Common;
using JobSite.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;

namespace JobSite.Application.IRepository;

public interface IAccountRepository
{
    IQueryable<Account> GetQuery();
    Task<Account> AddAsync(Account entity, CancellationToken cancellationToken);
    Task<Account> UpdateAsync(Account entity, CancellationToken cancellationToken);
    Task<Account> DeleteAsync(Account entity, CancellationToken cancellationToken);
    Task<List<Account>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken);
    Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, IEnumerable<Expression<Func<Account, BaseEntity>>> includes, CancellationToken cancellationToken);
    Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, Func<IQueryable<Account>, IIncludableQueryable<Account, object>> includeQuery, CancellationToken cancellationToken);
    Task<List<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, Func<IQueryable<Account>, IOrderedQueryable<Account>> sort, CancellationToken cancellationToken);
    Task<Account> GetSingleOrDefaultAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken);
    Task<Account> GetSingleOrDefaultAsync(Expression<Func<Account, bool>> predicate, IEnumerable<Expression<Func<Account, BaseEntity>>> includes, CancellationToken cancellationToken);
    Task<Account> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}