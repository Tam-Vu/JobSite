using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Domain.Entities;
public class Account : IdentityUser<Guid>
{
    public Boolean IsDisabled { get; set; } = false;
}