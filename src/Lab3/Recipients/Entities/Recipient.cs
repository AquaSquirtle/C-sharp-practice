using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;

public class Recipient : IRecipient
{
    private readonly IEndPoint _endPoint;

    public string Name { get; }

    public Recipient(IEndPoint endPoint)
    {
        _endPoint = endPoint;
        Name = endPoint.Name;
    }

    public bool TrySendMessage(Message message)
    {
        return _endPoint.ReceiveMessage(message);
    }
}