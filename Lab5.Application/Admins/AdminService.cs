using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;

    private readonly CurrentAdminService _admin;

    public AdminService(IAdminRepository repository, CurrentAdminService admin)
    {
        _repository = repository;
        _admin = admin;
    }

    public AdminServiceResult VerifyPassword(string password)
    {
        if (!_repository.GetSystemPassword().Equals(password, StringComparison.Ordinal))
        {
            return new AdminServiceResult.WrongPassword();
        }

        _admin.Authorized = true;

        return new AdminServiceResult.Success();
    }

    public AdminServiceResult SetPassword(string newPassword)
    {
        _repository.SetSystemPassword(newPassword);
        return new AdminServiceResult.Success();
    }
}