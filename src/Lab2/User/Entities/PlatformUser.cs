using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.User.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

public class PlatformUser : IPlatformUser
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public PlatformUser(string name)
    {
        Id = EntityCounter<IPlatformUser>.Next();
        Name = name;
    }

    private PlatformUser()
    {
        Id = EntityCounter<IPlatformUser>.Next();
    }

    public class UserBuilder : IUserBuilder
    {
        private string _name = string.Empty;

        public IUserBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IPlatformUser Build()
        {
            return new PlatformUser(_name);
        }
    }
}