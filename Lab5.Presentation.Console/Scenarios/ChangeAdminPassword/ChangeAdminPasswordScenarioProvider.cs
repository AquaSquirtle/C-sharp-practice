using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.ChangeAdminPassword;

public class ChangeAdminPasswordScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;

    private readonly ICurrentAdminService _currentAdminService;

    public ChangeAdminPasswordScenarioProvider(IAdminService adminService, ICurrentAdminService currentAdminService)
    {
        _adminService = adminService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_currentAdminService.Authorized)
        {
            scenario = null;
            return false;
        }

        scenario = new ChangeAdminPasswordScenario(_adminService);
        return true;
    }
}