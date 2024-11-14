using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

public class Messenger : IMessenger
{
    public string Name { get; }

    public Messenger(string name)
    {
        Name = name;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name}: {message}");
    }
}