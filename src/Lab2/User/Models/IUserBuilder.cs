using Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Models;

public interface IUserBuilder
{
    public IUserBuilder SetName(string name);

    public IPlatformUser Build();
}