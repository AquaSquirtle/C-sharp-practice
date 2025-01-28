using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Admin;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Back;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ChangeAdminPassword;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Create;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Deposit;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ExitApp;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.GetBalance;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.OperationsHistory;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.User;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, AdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BackScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangeAdminPasswordScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ExitScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, OperationHistoryScenarioProvider>();
        return collection;
    }
}