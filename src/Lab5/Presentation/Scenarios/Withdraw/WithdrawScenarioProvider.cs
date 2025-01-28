using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Withdraw;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly ICheckService _checkService;

    private readonly ICurrentCheckService _currentCheckService;

    public WithdrawScenarioProvider(ICheckService checkService, ICurrentCheckService currentCheckService)
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

        scenario = new WithdrawScenario(_checkService);
        return true;
    }
}