namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public interface IMessenger
{
    public void ReceiveMessage(string message);

    public string Name { get; }
}