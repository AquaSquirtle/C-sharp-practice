using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class DisplayAdapter : IEndPoint
{
    private readonly IDisplay _display;

    public string Name { get; } = "Display";

    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public bool TryReceiveMessage(Message message)
    {
        _display.ReceiveMessage(message.Body);
        return true;
    }
}