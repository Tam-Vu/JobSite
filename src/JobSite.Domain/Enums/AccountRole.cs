using System.ComponentModel.DataAnnotations;

namespace JobSite.Domain.Enums;

public enum AccountRole
{
    [Display(Name = "Admin")]
    Admin,
    [Display(Name = "Employer")]
    Employer,
    [Display(Name = "Employee")]
    Employee,
}