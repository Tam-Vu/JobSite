using JobSite.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Domain.Entities;

public class Employee : BaseAuditableEntity
{
    public required string Fullname { get; set; }
    public string? Image { get; set; }
    public string? Address { get; set; }
    public required Guid AccountId { get; init; }
    public Account Account { get; set; } = null!;
    public ICollection<Resume> Resumes { get; private set; } = new HashSet<Resume>();

    // public Employee(Guid id, string image, string address, string fullname, string phone, string email, Guid accountId)
    //     : base(id == Guid.Empty ? Guid.NewGuid() : id)
    // {
    //     this.Fullname = fullname;
    //     this.Image = image;
    //     this.Address = address;
    //     this.Phone = phone;
    //     this.Email = email;
    //     this.AccountId = accountId;
    // }
}