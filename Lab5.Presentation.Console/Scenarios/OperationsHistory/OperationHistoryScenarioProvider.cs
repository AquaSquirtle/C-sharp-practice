using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Transactions;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.OperationsHistory;

public class OperationHistoryScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly ICurrentAdminService _adminService;

    public OperationHistoryScenarioProvider(ITransactionService transactionService, ICurrentAdminService adminService)
    {
        _transactionService = transactionService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_adminService.Authorized)
        {
            scenario = null;
            return false;
        }

        scenario = new OperationHistoryScenario(_transactionService);
        return true;
    }
}