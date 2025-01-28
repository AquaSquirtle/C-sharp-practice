using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly ICheckService _checkService;

    public GetBalanceScenario(ICheckService checkService)
    {
        _checkService = checkService;
    }

    public string Name => "GetBalance";

    public void Run()
    {
        CheckServiceResult checkResult = _checkService.GetBalance();

        string message = checkResult switch
        {
            CheckServiceResult.Success => $"Your balance is {checkResult.Data}",
            CheckServiceResult.CheckServiceError => checkResult.Message,
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}