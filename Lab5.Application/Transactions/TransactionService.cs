using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<string> GetLastTransactions()
    {
        return _repository.GetLastTransactions();
    }
}