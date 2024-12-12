using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Create;

public class CreateScenario : IScenario
{
    private readonly ICheckService _checkService;

    public CreateScenario(ICheckService checkService)
    {
        _checkService = checkService;
    }

    public string Name => "Create";

    public void Run()
    {
        int checkNumber = AnsiConsole.Ask<int>($"Enter check number:");
        int pin = AnsiConsole.Ask<int>($"Enter pin:");

        CheckServiceResult checkResult = _checkService.CreateCheck(checkNumber, pin);

        string message = checkResult switch
        {
            CheckServiceResult.Success => "Check created successfully",
            CheckServiceResult.CheckServiceError => checkResult.Message,
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}