using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

public class MessengerAdapter : IEndPoint
{
    private readonly IMessenger _messenger;

    public string Name => _messenger.Name;

    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public bool TryReceiveMessage(Message message)
    {
        _messenger.ReceiveMessage(message.Body);
        return true;
    }
}