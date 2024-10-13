using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Employee : BaseAuditableEntity
{
    public required string name { get; set; }
    public string? image { get; set; }
    public string? address { get; set; }
    public string? phone { get; set; }
    public string? email { get; set; }
    public Guid accountId { get; }
    public ICollection<Resume> resumes { get; private set; } = new HashSet<Resume>();

    public Employee(Guid id, string image, string address, string name, string phone, string email, Guid accountId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.name = name;
        this.image = image;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.accountId = accountId;
    }
}