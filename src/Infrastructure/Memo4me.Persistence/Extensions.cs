using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Memo4me.Persistence;

public static class Extensions
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql("Username=postgres;Password=123;Host=db;Port=5432;Database=MemoDb");
        });
    }
}