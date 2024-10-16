using Microsoft.Extensions.Hosting;
using MongoDB.Entities;
using USP.Domain.Entities;

namespace USP.Worker;

public class NotifyUserWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync();
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
    
    private async Task DoWorkAsync()
    {
        var results = await DB.Find<User>().ExecuteAsync();

        foreach (var user in results)
        {
            Console.WriteLine(user.Email);
        }
    }
}
