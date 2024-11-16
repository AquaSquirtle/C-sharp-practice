using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MessagesTests
{
    private readonly Message.MessagBuilder _messagBuilder = new Message.MessagBuilder();

    [Fact]
    public void UnreadMessageTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.High)
            .Build();

        var user = new User("Name");
        var recipient = new Recipient(user);
        recipient.TrySendMessage(message);
        Assert.Equal(user.TryGetMessageStatus(message.MessageId), MessageStatus.Unread);
    }

    [Fact]
    public void MarkAsReadTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.High)
            .Build();

        var user = new User("Name");
        var recipient = new Recipient(user);
        recipient.TrySendMessage(message);
        user.MarkAsRead(message.MessageId);
        Assert.Equal(user.TryGetMessageStatus(message.MessageId), MessageStatus.Read);
    }

    [Fact]
    public void MarkAsReadAlreadyReadTextTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.High)
            .Build();

        var user = new User("Name");
        var recipient = new Recipient(user);
        recipient.TrySendMessage(message);
        user.MarkAsRead(message.MessageId);
        Assert.Throws<ArgumentException>(() => user.MarkAsRead(message.MessageId));
    }

    [Fact]
    public void FilterMessageTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.Low)
            .Build();
        var user = new Mock<IEndPoint>();
        var recipient = new Recipient(user.Object);
        var filterRecipient = new RecipientFilterProxy(recipient, Priority.High);
        filterRecipient.TrySendMessage(message);
        user.Verify(u => u.TryReceiveMessage(It.Is<Message>(m => m.Priority < Priority.High)), Times.Never);
    }

    [Fact]
    public void LogMessageTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.Low)
            .Build();
        var user = new User("Name");
        var logger = new Mock<ILogger>();
        var recipient = new Recipient(user);
        var recipientLogger = new RecipientLogDecorator(recipient, logger.Object);
        recipientLogger.TrySendMessage(message);

        logger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void MessengerTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.Low)
            .Build();
        var messenger = new Mock<IMessenger>();
        messenger.SetupGet(m => m.Name).Returns("Name");
        var messengerAdapter = new MessengerAdapter(messenger.Object);
        var recipient = new Recipient(messengerAdapter);
        recipient.TrySendMessage(message);

        messenger.Verify(m => m.ReceiveMessage(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void TwoFiltersMessageTest()
    {
        Message message = _messagBuilder
            .BuildHeader("Message")
            .BuildBody("Message text")
            .BuildPriority(Priority.Low)
            .Build();
        var user = new Mock<IEndPoint>();
        var recipient = new Recipient(user.Object);
        var filterRecipient = new RecipientFilterProxy(recipient, Priority.High);
        var filterRecipient2 = new RecipientFilterProxy(recipient, Priority.Low);
        filterRecipient.TrySendMessage(message);
        filterRecipient2.TrySendMessage(message);
        user.Verify(u => u.TryReceiveMessage(It.Is<Message>(m => m.Priority < Priority.High)), Times.Once);
    }
}