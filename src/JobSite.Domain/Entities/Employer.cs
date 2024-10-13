using JobSite.Domain.Common;
using JobSite.Domain.Entities;
using JobSite.Domain.Enums;

namespace CleanArchitecture.Domain.Entities;

public class Employer : BaseAuditableEntity
{
    public required string name { get; set; }
    public string? description { get; set; }
    public required Sector sector { get; set; }
    public string? location { get; set; }
    public string? website { get; set; }
    public Guid accountId { get; }
    public ICollection<Job> jobs { get; private set; } = new HashSet<Job>();
    public Employer(Guid id, string name, string description, Sector sector, string location, string website, Guid accountId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.name = name;
        this.description = description;
        this.sector = sector;
        this.location = location;
        this.website = website;
        this.accountId = accountId;
    }
}