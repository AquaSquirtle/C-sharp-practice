using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandInvokers.Entities;

public interface ICommandInvoker
{
    public void SetCommand(ICommand command);

    public void TryInvoke();
}