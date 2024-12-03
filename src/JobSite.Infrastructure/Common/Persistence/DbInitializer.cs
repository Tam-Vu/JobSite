using System.Formats.Asn1;
using JobSite.Domain.Enums;
using JobSite.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Infrastructure.Common.Persistence;

public class DbInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Account> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public DbInitializer(ApplicationDbContext context, UserManager<Account> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedingData()
    {
        Console.WriteLine("seeding data");
        foreach (AccountRole accountRole in Enum.GetValues(typeof(AccountRole)))
        {
            var name = accountRole.GetEnumName();
            var roleInDb = _roleManager.Roles.SingleOrDefault(x => x.Name == accountRole.GetEnumDisplayName());
            if (roleInDb == null)
            {
                await _roleManager.CreateAsync(new Role
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    NormalizedName = name.ToUpper()
                });
            }

        }
        if (await _userManager.FindByNameAsync("admin1") == null)
        {
            var user = new Account
            {
                Id = Guid.NewGuid(),
                UserName = "admin1",
                NormalizedUserName = "ADMIN1",
                Email = "vuthanhtam12062003@gmail.com",
                NormalizedEmail = "VUTHANHTAM12062003@GMAIL.COM",
                PhoneNumber = "0123456789",
                SecurityStamp = Guid.NewGuid().ToString("D"),
                EmailConfirmed = true,
            };
            var createResult = await _userManager.CreateAsync(user, "Admin123!");
            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => $"{e.Code}: {e.Description}"));
                throw new Exception($"Failed to create admin user: {errors}");
            }
            var roleAddResult = await _userManager.AddToRoleAsync(user, nameof(AccountRole.Admin));
            if (!roleAddResult.Succeeded)
            {
                throw new Exception("Failed to assign role to admin user: " + string.Join(", ", roleAddResult.Errors.Select(e => e.Description)));
            }
            _context.SaveChanges();
        }
    }
}