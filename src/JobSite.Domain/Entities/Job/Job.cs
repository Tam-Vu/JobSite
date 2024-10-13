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
    public int appliedResumes { get; set; }
    public JobStatus jobStatus { get; set; }
    public ICollection<Requirement> requirements { get; set; } = new HashSet<Requirement>();
    public ICollection<Application> applications { get; set; } = new HashSet<Application>();
    public ICollection<InterviewSchedule> interviewSchedules { get; set; } = new HashSet<InterviewSchedule>();
    public required Guid employerId { get; init; }
    public Employer? employer { get; set; }

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
        this.appliedResumes = 0;
        this.employerId = employerId;
    }
}