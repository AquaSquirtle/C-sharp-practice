using Itmo.ObjectOrientedProgramming.Lab5.Application.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Checks;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Transactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<ICheckService, CheckService>();
        collection.AddScoped<ITransactionService, TransactionService>();
        collection.AddScoped<CurrentCheckService>();
        collection.AddScoped<CurrentAdminService>();
        collection.AddScoped<ICurrentAdminService>(p => p.GetRequiredService<CurrentAdminService>());
        collection.AddScoped<ICurrentCheckService>(p => p.GetRequiredService<CurrentCheckService>());

        return collection;
    }
}