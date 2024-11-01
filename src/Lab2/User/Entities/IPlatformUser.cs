using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

public interface IPlatformUser : IEntity<IPlatformUser>
{
    string Name { get; }
}