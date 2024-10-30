using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

public interface IPlatformUser : IAddable
{
    int Id { get; }

    string Name { get; }
}