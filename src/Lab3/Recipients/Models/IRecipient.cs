using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

public interface IRecipient
{
    bool TrySendMessage(Message message);

    string Name { get; }
}