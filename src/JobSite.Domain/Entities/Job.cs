using System.Data.SqlTypes;
using JobSite.Domain.Common;
using JobSite.Domain.Enums;
namespace JobSite.Domain.Entities;

public class Job : BaseAuditableEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? Requirement { get; set; }
    public string? Benefit { get; set; }
    public Decimal Salary { get; set; }
    public JobType JobType { get; set; }
    public int AppliedResumes { get; set; }
    public JobStatus Status { get; set; }
    public ICollection<JobApplication> Applications { get; set; } = new HashSet<JobApplication>();
    public ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new HashSet<InterviewSchedule>();
    public required Guid EmployerId { get; init; }
    public Employer Employer { get; set; } = null!;

    // public Job(Guid id, string title, string description, string location, Decimal salary, JobType jobType,
    // Guid employerId) : base(id == Guid.Empty ? Guid.NewGuid() : id)
    // {
    //     this.Title = title;
    //     this.Description = description;
    //     this.Location = location;
    //     this.Salary = salary;
    //     this.JobType = jobType;
    //     this.JobStatus = JobStatus.Active;
    //     this.AppliedResumes = 0;
    //     this.EmployerId = employerId;
    // }
}