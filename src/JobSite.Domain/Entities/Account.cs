using JobSite.Domain.Common;
using JobSite.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Domain.Entities;
public class Account : IdentityUser<Guid>
{
    public Boolean IsDisabled { get; set; } = false;
    // public Account(Guid id, string username, string password, string image, string address) : base(id)
    // {
    //     this.Username = username;
    //     this.Password = password;
    //     this.Image = image;
    //     this.Address = address;
    // }
}