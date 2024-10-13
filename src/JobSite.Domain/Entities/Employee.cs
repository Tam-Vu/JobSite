using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Employee : BaseAuditableEntity
{
    public required string fullname { get; set; }
    public string? image { get; set; }
    public string? address { get; set; }
    public string? phone { get; set; }
    public string? email { get; set; }
    public required Guid accountId { get; init; }
    public Account? account { get; set; }
    public ICollection<Resume> resumes { get; private set; } = new HashSet<Resume>();

    public Employee(Guid id, string image, string address, string fullname, string phone, string email, Guid accountId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.fullname = fullname;
        this.image = image;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.accountId = accountId;
    }
}