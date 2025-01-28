namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ExitApp;

public class ExitScenario : IScenario
{
    public string Name => "Exit";

    public void Run()
    {
        Environment.Exit(0);
    }
}