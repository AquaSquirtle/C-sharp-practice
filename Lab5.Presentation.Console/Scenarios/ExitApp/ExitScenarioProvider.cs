using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ExitApp;

public class ExitScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ExitScenario();
        return true;
    }
}