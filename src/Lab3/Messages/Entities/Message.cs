using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class Message
{
    public int MessageId { get; }

    public string Header { get; }

    public string Body { get; }

    public Priority Priority { get; }

    public Message(string header, string body, Priority priority = Priority.Normal)
    {
        MessageId = EntityCounter<Message>.Next();
        Header = header;
        Body = body;
        Priority = priority;
    }

    public Message Clone()
    {
        return new Message(Header, Body, Priority);
    }

    public class MessagBuilder : IMessageBuilder
    {
        private string header = string.Empty;
        private string body = string.Empty;
        private Priority priority = Priority.Normal;

        public IMessageBuilder Reset()
        {
            header = string.Empty;
            body = string.Empty;
            priority = Priority.Normal;
            return this;
        }

        public IMessageBuilder BuildHeader(string header)
        {
            this.header = header;
            return this;
        }

        public IMessageBuilder BuildBody(string body)
        {
            this.body = body;
            return this;
        }

        public IMessageBuilder BuildPriority(Priority priority)
        {
            this.priority = priority;
            return this;
        }

        public Message Build()
        {
            return new Message(header, body, priority);
        }
    }
}