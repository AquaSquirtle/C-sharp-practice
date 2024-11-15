namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

public interface IMessenger
{
    void ReceiveMessage(string message);

    string Name { get; }
}