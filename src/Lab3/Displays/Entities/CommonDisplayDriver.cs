using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class CommonDisplayDriver : IDisplayDriver
{
    private IOutput _currentColor = Output.Rgb(0, 0, 0);

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(int r, int g, int b)
    {
        _currentColor = Output.Rgb((byte)r, (byte)g, (byte)b);
    }

    public void ShowText(string text)
    {
        Console.WriteLine(_currentColor.Text(text));
    }
}