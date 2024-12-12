using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Admins;

public class CurrentAdminService : ICurrentAdminService
{
    public bool Authorized { get; set; } = false;

    public void Logout()
    {
        Authorized = false;
    }
}