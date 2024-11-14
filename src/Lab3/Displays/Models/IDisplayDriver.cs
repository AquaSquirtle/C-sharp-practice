namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplayDriver
{
    void SetColor(int r, int g, int b);

    void Clear();

    void ShowText(string text);
}