using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.User;

public class UserScenarioProvider : IScenarioProvider
{
    private readonly ICheckService _service;

    private readonly ICurrentAdminService _currentAdminService;

    private readonly ICurrentCheckService _currentCheckService;

    public UserScenarioProvider(
        ICheckService service,
        ICurrentAdminService currentAdminService,
        ICurrentCheckService currentCheckService)
    {
        _service = service;
        _currentAdminService = currentAdminService;
        _currentCheckService = currentCheckService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdminService.Authorized || _currentCheckService.Check != null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserScenario(_service);
        return true;
    }
}