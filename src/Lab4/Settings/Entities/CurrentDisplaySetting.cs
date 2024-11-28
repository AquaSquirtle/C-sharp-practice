using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

public class CurrentDisplaySetting : ISetting<IDisplay>
{
    public string Key { get; } = "CurrentDisplaySetting";

    private IDisplay? _value;

    public IDisplay GetValue()
    {
        if (_value == null)
        {
            return new ConsoleDisplayAdapter(new ConsoleDisplay());
        }

        return _value;
    }

    public void Update(IDisplay value)
    {
        _value = value;
    }
}