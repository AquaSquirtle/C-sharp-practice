using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using System.Security.Cryptography;
using System.Text;

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
        var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        string pass = Convert.ToBase64String(hashBytes);

        if (!_repository.GetSystemPassword().Equals(pass, StringComparison.Ordinal))
        {
            return new AdminServiceResult.WrongPassword();
        }

        _admin.Authorized = true;

        return new AdminServiceResult.Success();
    }

    public AdminServiceResult SetPassword(string newPassword)
    {
        var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
        string pass = Convert.ToBase64String(hashBytes);
        _repository.SetSystemPassword(pass);
        return new AdminServiceResult.Success();
    }
}