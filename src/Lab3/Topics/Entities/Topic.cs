using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public class Topic
{
    private readonly List<IRecipient> _recipients = new List<IRecipient>();

    public string Name { get; }

    public Topic(string name)
    {
        Name = name;
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.TrySendMessage(message);
        }
    }
}