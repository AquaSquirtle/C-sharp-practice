using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IEndPoint
{
    string Name { get; }

    bool TryReceiveMessage(Message message);
}