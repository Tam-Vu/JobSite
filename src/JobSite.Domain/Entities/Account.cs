using JobSite.Domain.Common;
using JobSite.Domain.Enums;

namespace JobSite.Domain.Entities;
public class Account : BaseAuditableEntity
{
    public string username { get; set; }
    public string password { get; set; }
    public string? image { get; set; }
    public string? address { get; set; }
    public AccountRole role { get; set; }
    public Boolean isDisabled { get; set; } = false;

    public Account(Guid id, string username, string password, string image, string address) : base(id)
    {
        this.username = username;
        this.password = password;
        this.image = image;
        this.address = address;
    }
}