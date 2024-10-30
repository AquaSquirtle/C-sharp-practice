using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.User.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

public class PlatformUser : IPlatformUser
{
    private static int _nextId;

    public int Id { get; private set; }

    public string Name { get; private set; } = "Undefined";

    private PlatformUser()
    {
        Id = _nextId++;
    }

    public class UserBuilder : IUserBuilder
    {
        private readonly PlatformUser _platformUser = new PlatformUser();

        public IUserBuilder SetName(string name)
        {
            _platformUser.Name = name;
            return this;
        }

        public IPlatformUser Build()
        {
            return _platformUser;
        }
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<IPlatformUser>(this);
    }
}