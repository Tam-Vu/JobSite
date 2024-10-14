
using System.Reflection;
using AvailableTemplate.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobSite.Infrastructure.Common.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}