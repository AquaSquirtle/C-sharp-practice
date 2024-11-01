using Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Models;

public interface IUserBuilder
{
    IUserBuilder SetName(string name);

    IPlatformUser Build();
}