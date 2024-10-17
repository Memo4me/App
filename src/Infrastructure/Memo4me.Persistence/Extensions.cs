﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Memo4me.Persistence;

public static class Extensions
{
    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql(connectionString);
        });
    }
}