using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Admin;

public class AdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin";

    public void Run()
    {
        string password = AnsiConsole.Ask("Enter your password: ", defaultValue: string.Empty);

        AdminServiceResult checkResult = _adminService.VerifyPassword(password);

        string message = checkResult switch
        {
            AdminServiceResult.Success => "Logged in as administrator",
            AdminServiceResult.WrongPassword => "Wrong password",
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        if (checkResult is not AdminServiceResult.Success)
        {
            Environment.Exit(1);
        }

        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}