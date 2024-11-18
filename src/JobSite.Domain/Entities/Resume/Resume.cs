

using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Resume : BaseAuditableEntity
{
    public required string Title { get; set; }
    public string? Experience { get; set; }
    public string? Education { get; set; }
    public string? File { get; set; }
    public required Guid EmployeeId { get; init; }
    public Employee Employee { get; set; } = null!;
    public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
    public ICollection<ExperienceDetail> ExperienceDetails { get; set; } = new HashSet<ExperienceDetail>();
    public ICollection<JobApplication> Applications { get; private set; } = new HashSet<JobApplication>();
    public ICollection<InterviewSchedule> InverviewSchedules { get; private set; } = new HashSet<InterviewSchedule>();
}