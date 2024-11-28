using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandInvokers.Entities;

public class CommandInvoker : ICommandInvoker
{
    private ICommand? _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void TryInvoke()
    {
        _command?.Execute();
    }
}