

using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Resume : BaseAuditableEntity
{
    public required string name { get; set; }
    public string? experience { get; set; }
    public string? education { get; set; }
    public string? file { get; set; }
    public Guid employeeId { get; init; }
    ICollection<Skill> skills { get; set; } = new HashSet<Skill>();
    public ICollection<Application> applications { get; private set; } = new HashSet<Application>();
    public ICollection<InterviewSchedule> InverviewSchedules { get; private set; } = new HashSet<InterviewSchedule>();
    public Resume(Guid id, string name, string experience, string education, ICollection<Skill> skills, string file, Guid employeeId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.name = name;
        this.experience = experience;
        this.education = education;
        this.employeeId = employeeId;
        this.file = file;
        this.skills = skills;
    }
}