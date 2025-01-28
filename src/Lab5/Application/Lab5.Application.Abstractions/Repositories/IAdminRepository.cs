namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    string GetSystemPassword();

    void SetSystemPassword(string password);
}