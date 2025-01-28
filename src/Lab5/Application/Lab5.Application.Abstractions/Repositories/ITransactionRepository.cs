namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    IEnumerable<string> GetLastTransactions();

    void AddTransaction(int checkNumber, string transaction);
}