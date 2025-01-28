using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Transactions;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.OperationsHistory;

public class OperationHistoryScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public OperationHistoryScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "Operation history";

    public void Run()
    {
        foreach (string log in _transactionService.GetLastTransactions())
        {
            AnsiConsole.WriteLine(log);
        }

        AnsiConsole.Markup("[green]Press any key to continue...[/]");
        System.Console.ReadKey(intercept: true);
    }
}