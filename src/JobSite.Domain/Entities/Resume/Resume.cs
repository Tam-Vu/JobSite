

using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Resume : BaseAuditableEntity
{
    public required string title { get; set; }
    public string? experience { get; set; }
    public string? education { get; set; }
    public string? file { get; set; }
    public required Guid employeeId { get; init; }
    public Employee? employee { get; set; }
    public ICollection<Skill> skills { get; set; } = new HashSet<Skill>();
    public ICollection<Application> applications { get; private set; } = new HashSet<Application>();
    public ICollection<InterviewSchedule> InverviewSchedules { get; private set; } = new HashSet<InterviewSchedule>();
    public Resume(Guid id, string title, string experience, string education, ICollection<Skill> skills, string file, Guid employeeId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.title = title;
        this.experience = experience;
        this.education = education;
        this.employeeId = employeeId;
        this.file = file;
        this.skills = skills;
    }
}