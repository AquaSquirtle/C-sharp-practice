using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _path;
    private string _currentColor = "RGB(0, 0, 0)";

    public FileDisplayDriver(string path)
    {
        _path = path;
    }

    public void Clear()
    {
        File.WriteAllText(_path, string.Empty);
    }

    public void SetColor(int r, int g, int b)
    {
        _currentColor = $"RGB({r}, {g}, {b})";
    }

    public void ShowText(string text)
    {
        var writer = new StreamWriter(_path, append: true);
        writer.Write($"{_currentColor}: {text}");
    }
}