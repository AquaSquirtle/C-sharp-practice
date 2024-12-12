using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.User;

public class UserScenario : IScenario
{
    private readonly ICheckService _checkService;

    public UserScenario(ICheckService checkService)
    {
        _checkService = checkService;
    }

    public string Name => "User";

    public void Run()
    {
        int checkNumber = AnsiConsole.Ask<int>($"Enter check number:");
        int pin = AnsiConsole.Ask<int>($"Enter pin:");

        CheckServiceResult checkResult = _checkService.LoadCheck(checkNumber, pin);

        string message = checkResult switch
        {
            CheckServiceResult.Success => "Check found",
            CheckServiceResult.CheckServiceError => checkResult.Message,
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}