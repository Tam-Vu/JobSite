
using System.Reflection;
using JobSite.Application.Common.Interfaces;
using JobSite.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobSite.Infrastructure.Common.Persistence;
public class ApplicationDbContext : IdentityDbContext<Account, UserRole, Guid>, IApplicationDbContext
{
    public required DbSet<Job> Jobs { get; set; }
    public required DbSet<Employee> Employees { get; set; }
    public required DbSet<Employer> Employers { get; set; }
    public required DbSet<Account> Accounts { get; set; }
    public required DbSet<Resume> Resumes { get; set; }
    public required DbSet<Skill> Skills { get; set; }
    public required DbSet<JobApplication> JobApplications { get; set; }
    public required DbSet<InterviewSchedule> interviewSchedules { get; set; }
    public required DbSet<ExperienceDetail> experienceDetails { get; set; }
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