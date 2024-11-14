using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;

public class RecipientLogDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    public string Name { get;  }

    public RecipientLogDecorator(IRecipient recipient)
    {
        _recipient = recipient;
        Name = recipient.Name;
    }

    public bool TrySendMessage(Message message)
    {
        if (_recipient.TrySendMessage(message))
        {
            Console.WriteLine($"Message {message.MessageId} has been delivered to {_recipient.Name}");
            return true;
        }

        Console.WriteLine($"Message {message.MessageId} has not been delivered to {_recipient.Name}");
        return false;
    }
}