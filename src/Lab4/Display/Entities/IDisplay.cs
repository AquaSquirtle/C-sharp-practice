namespace Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;

public interface IDisplay
{
    string Key { get; }

    void Display(string text);
}