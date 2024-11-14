using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;

public class RecipientGroup : IRecipient
{
    private readonly List<IRecipient> _recipients = new List<IRecipient>();

    public string Name { get; } = "Group";

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public bool TrySendMessage(Message message)
    {
        bool allDelivered = true;

        foreach (IRecipient recipient in _recipients)
        {
            if (!recipient.TrySendMessage(message))
            {
                allDelivered = false;
            }
        }

        return allDelivered;
    }
}