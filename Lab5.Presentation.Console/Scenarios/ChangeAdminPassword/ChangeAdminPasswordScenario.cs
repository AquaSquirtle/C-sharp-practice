using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ChangeAdminPassword;

public class ChangeAdminPasswordScenario : IScenario
{
    private readonly IAdminService _adminService;

    public ChangeAdminPasswordScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Change Admin Password";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter new password: ");

        AdminServiceResult checkResult = _adminService.SetPassword(password);

        string message = checkResult switch
        {
            AdminServiceResult.Success => "Password changed successfully.",
            AdminServiceResult.WrongPassword => "Unexpected error occured.",
            _ => throw new InvalidOperationException(),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}