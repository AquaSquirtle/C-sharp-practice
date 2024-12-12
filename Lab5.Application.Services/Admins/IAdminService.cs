namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;

public interface IAdminService
{
    AdminServiceResult VerifyPassword(string password);

    AdminServiceResult SetPassword(string newPassword);
}