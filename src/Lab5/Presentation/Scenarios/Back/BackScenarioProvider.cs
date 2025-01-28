using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Back;

public class BackScenarioProvider : IScenarioProvider
{
    private readonly ICurrentAdminService _currentAdminService;

    private readonly ICurrentCheckService _currentCheckService;

    public BackScenarioProvider(ICurrentAdminService currentAdminService, ICurrentCheckService currentCheckService)
    {
        _currentAdminService = currentAdminService;
        _currentCheckService = currentCheckService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_currentAdminService.Authorized && _currentCheckService.Check == null)
        {
            scenario = null;
            return false;
        }

        scenario = new BackScenario(_currentAdminService, _currentCheckService);
        return true;
    }
}