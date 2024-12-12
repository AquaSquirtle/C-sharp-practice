using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Deposit;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly ICheckService _checkService;

    private readonly ICurrentCheckService _currentCheckService;

    public DepositScenarioProvider(ICheckService checkService, ICurrentCheckService currentCheckService)
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

        scenario = new DepositScenario(_checkService);
        return true;
    }
}