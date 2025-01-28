using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Create;

public class CreateScenarioProvider : IScenarioProvider
{
    private readonly ICheckService _checkService;

    private readonly ICurrentCheckService _currentCheckService;

    public CreateScenarioProvider(ICheckService checkService, ICurrentCheckService currentCheckService)
    {
        _checkService = checkService;
        _currentCheckService = currentCheckService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentCheckService.Check != null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateScenario(_checkService);
        return true;
    }
}