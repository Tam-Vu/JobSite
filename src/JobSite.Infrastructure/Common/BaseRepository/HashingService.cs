using JobSite.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace JobSite.Infatructure.Services;
public class HashingService : PasswordHasher<Account>
{
}