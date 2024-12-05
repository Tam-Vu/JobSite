using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobSite.Infrastructure.Accounts.BackgroundServices;

public class DeleteUnconfirmedAccount : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    public DeleteUnconfirmedAccount(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Account>>();
                var users = await userManager.Users.Where(x => x.EmailConfirmed == false && x.Created.AddMinutes(2) < DateTime.Now).ToListAsync();
                foreach (var user in users)
                {
                    await userManager.DeleteAsync(user);
                }
                await Task.Delay(TimeSpan.FromMinutes(3), stoppingToken);
            }
        }
    }
}