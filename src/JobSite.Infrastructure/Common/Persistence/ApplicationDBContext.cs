
using System.Reflection;
using JobSite.Application.Common.Interfaces;
using JobSite.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobSite.Infrastructure.Common.Persistence;
public class ApplicationDbContext : IdentityDbContext<Account, UserRole, Guid>, IApplicationDbContext
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<InterviewSchedule> interviewSchedules { get; set; }
    public DbSet<ExperienceDetail> experienceDetails { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.DisplayName());
        }
    }
}