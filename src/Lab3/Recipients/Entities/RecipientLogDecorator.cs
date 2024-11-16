using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;

public class RecipientLogDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public string Name { get;  }

    public RecipientLogDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        Name = recipient.Name;
        _logger = logger;
    }

    public bool TrySendMessage(Message message)
    {
        if (_recipient.TrySendMessage(message))
        {
            _logger.Log($"Message {message.MessageId} has been delivered to {_recipient.Name}");
            return true;
        }

        Console.WriteLine($"Message {message.MessageId} has not been delivered to {_recipient.Name}");
        return false;
    }
}