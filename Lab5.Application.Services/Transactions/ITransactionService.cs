namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Transactions;

public interface ITransactionService
{
    IEnumerable<string> GetLastTransactions();
}