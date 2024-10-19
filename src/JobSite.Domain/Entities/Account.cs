using JobSite.Domain.Common;
using JobSite.Domain.Enums;

namespace JobSite.Domain.Entities;
public class Account : BaseAuditableEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Image { get; set; }
    public string? Address { get; set; }
    public AccountRole Role { get; set; }
    public Boolean IsDisabled { get; set; } = false;

    // public Account(Guid id, string username, string password, string image, string address) : base(id)
    // {
    //     this.Username = username;
    //     this.Password = password;
    //     this.Image = image;
    //     this.Address = address;
    // }
}