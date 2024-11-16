using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;

public class RecipientFilterProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly Priority _priority;

    public string Name { get; }

    public RecipientFilterProxy(IRecipient recipient, Priority priority)
    {
        _recipient = recipient;
        _priority = priority;
        Name = _recipient.Name;
    }

    public bool TrySendMessage(Message message)
    {
        if (message.Priority < _priority)
        {
            return false;
        }

        return _recipient.TrySendMessage(message);
    }
}