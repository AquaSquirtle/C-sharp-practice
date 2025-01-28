using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Deposit;

public class DepositScenario : IScenario
{
    private readonly ICheckService _checkService;

    public DepositScenario(ICheckService checkService)
    {
        _checkService = checkService;
    }

    public string Name => "Deposit";

    public void Run()
    {
        decimal moneyAmount = AnsiConsole.Ask<decimal>($"Enter amount of money:");

        CheckServiceResult checkResult = _checkService.TryDeposit(moneyAmount);

        string message = checkResult switch
        {
            CheckServiceResult.Success => "Deposit successful",
            CheckServiceResult.CheckServiceError => checkResult.Message,
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}