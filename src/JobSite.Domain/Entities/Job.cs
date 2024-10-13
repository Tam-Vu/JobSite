using System.Data.SqlTypes;
using JobSite.Domain.Common;
using JobSite.Domain.Enums;
namespace JobSite.Domain.Entities;

public class Job : BaseAuditableEntity
{
    public required string title { get; set; }
    public string? description { get; set; }
    public string? location { get; set; }
    public SqlMoney salary { get; set; }
    public JobType jobType { get; set; }
    public JobStatus jobStatus { get; set; }
    public ICollection<Requirement> requirements { get; set; } = new HashSet<Requirement>();
    public ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    public ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new HashSet<InterviewSchedule>();
    public Guid employerId { get; }
    public Job(Guid id, string title, string description, string location, SqlMoney salary, JobType jobType,
    JobStatus jobStatus, ICollection<Requirement> requirements, Guid employerId) : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.title = title;
        this.description = description;
        this.location = location;
        this.salary = salary;
        this.jobType = jobType;
        this.jobStatus = jobStatus;
        this.requirements = requirements;
        this.employerId = employerId;
    }
}