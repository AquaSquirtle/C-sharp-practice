using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _scenarioProviders;

    public ScenarioRunner(IEnumerable<IScenarioProvider> scenarioProviders)
    {
        _scenarioProviders = scenarioProviders;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios().OrderBy(x => x.Name).OrderBy(x =>
        {
            return x.Name switch
            {
                "Exit" => 1,
                _ => 0,
            };
        });

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _scenarioProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
            {
                yield return scenario;
            }
        }
    }
}