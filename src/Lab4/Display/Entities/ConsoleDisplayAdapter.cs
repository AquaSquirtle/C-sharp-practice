namespace Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;

public class ConsoleDisplayAdapter : IDisplay
{
    public string Key { get; } = "Console";

    private readonly ConsoleDisplay _display;

    public ConsoleDisplayAdapter(ConsoleDisplay display)
    {
        _display = display;
    }

    public void Display(string text)
    {
        _display.Display(text);
    }
}