using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public interface IMessageBuilder
{
    IMessageBuilder Reset();

    IMessageBuilder BuildHeader(string header);

    IMessageBuilder BuildBody(string body);

    IMessageBuilder BuildPriority(Priority priority);

    Message Build();
}