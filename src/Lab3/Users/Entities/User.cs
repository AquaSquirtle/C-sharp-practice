using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public class User : IEndPoint
{
    private readonly List<Message> _messages = new List<Message>();
    private readonly Dictionary<int, MessageStatus> _messageStatus = new Dictionary<int, MessageStatus>();

    public string Name { get;  }

    public User(string name)
    {
        Name = name;
    }

    public bool ReceiveMessage(Message message)
    {
        _messages.Add(message);
        _messageStatus.Add(message.MessageId, MessageStatus.Unread);
        return true;
    }

    public void MarkAsRead(int messageId)
    {
        if (!_messageStatus.ContainsKey(messageId))
        {
            throw new ArgumentException($"Message with id {messageId} does not exist");
        }

        if (_messageStatus[messageId] == MessageStatus.Read)
        {
            throw new ArgumentException($"Message with id {messageId} has already been read");
        }

        _messageStatus[messageId] = MessageStatus.Read;
    }

    public Message? TryGetMessage(int messageId)
    {
        return _messages.SingleOrDefault(m => m.MessageId == messageId);
    }

    public MessageStatus? TryGetMessageStatus(int messageId)
    {
        return _messageStatus.TryGetValue(messageId, out MessageStatus messageStatus) ? messageStatus : null;
    }
}