using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class CommonDisplay : IDisplay
{
    private readonly IDisplayDriver _driver;
    private string _savedMessage = string.Empty;

    public CommonDisplay(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ReceiveMessage(string message)
    {
        _savedMessage = message;
    }

    public void ShowMessageWithColor(int r, int g, int b)
    {
        _driver.Clear();
        _driver.SetColor(r, g, b);
        _driver.ShowText(_savedMessage);
    }

    public void ShowMessage()
    {
        _driver.Clear();
        _driver.ShowText(_savedMessage);
    }
}