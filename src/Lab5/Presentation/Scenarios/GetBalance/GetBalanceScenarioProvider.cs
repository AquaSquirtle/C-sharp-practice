using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.GetBalance;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICheckService _checkService;

    private readonly ICurrentCheckService _currentCheckService;

    public GetBalanceScenarioProvider(ICheckService checkService, ICurrentCheckService currentCheckService)
    {
        _checkService = checkService;
        _currentCheckService = currentCheckService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentCheckService.Check == null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetBalanceScenario(_checkService);
        return true;
    }
}