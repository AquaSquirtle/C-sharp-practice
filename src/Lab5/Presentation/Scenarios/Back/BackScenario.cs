using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Back;

public class BackScenario : IScenario
{
    private readonly ICurrentAdminService _currentAdminService;

    private readonly ICurrentCheckService _currentCheckService;

    public BackScenario(ICurrentAdminService currentAdminService, ICurrentCheckService currentCheckService)
    {
        _currentAdminService = currentAdminService;
        _currentCheckService = currentCheckService;
    }

    public string Name => "Back";

    public void Run()
    {
        if (_currentAdminService.Authorized)
        {
            _currentAdminService.Logout();
        }

        if (_currentCheckService.Check != null)
        {
            _currentCheckService.CloseCheck();
        }
    }
}