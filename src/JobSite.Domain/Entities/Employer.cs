using JobSite.Domain.Common;
using JobSite.Domain.Entities;
using JobSite.Domain.Enums;

namespace JobSite.Domain.Entities;

public class Employer : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public Sector? Sector { get; set; }
    public string? Location { get; set; }
    public string? Website { get; set; }
    public required Guid AccountId { get; init; }
    public Account Account { get; set; } = null!;
    public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    public Employer(Guid id, string name, string description, string location, string website, Guid accountId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.Name = name;
        this.Description = description;
        this.Location = location;
        this.Website = website;
        this.AccountId = accountId;
    }
}