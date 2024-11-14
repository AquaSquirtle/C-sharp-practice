namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplay
{
    void ShowMessage();

    void ShowMessageWithColor(int r, int g, int b);

    void ReceiveMessage(string message);
}