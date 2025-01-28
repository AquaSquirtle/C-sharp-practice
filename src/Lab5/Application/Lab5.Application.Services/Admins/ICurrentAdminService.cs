namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;

public interface ICurrentAdminService
{
    bool Authorized { get; }

    void Logout();
}