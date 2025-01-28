using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Checks;

public class CheckService : ICheckService
{
    private readonly ICheckRepository _checkRepository;

    private readonly ITransactionRepository _transactionRepository;

    private readonly CurrentCheckService _check;

    public CheckService(
        ICheckRepository checkRepository,
        CurrentCheckService check,
        ITransactionRepository transactionRepository)
    {
        _checkRepository = checkRepository;
        _check = check;
        _transactionRepository = transactionRepository;
    }

    public CheckServiceResult LoadCheck(int number, int pin)
    {
        _check.Check = _checkRepository.FindCheckByNumber(number);
        if (_check.Check is null)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Check number {number} is invalid",
            };
        }

        if (_check.Check.Pin != pin)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Pin {pin} is invalid",
            };
        }

        return new CheckServiceResult.Success();
    }

    public CheckServiceResult GetBalance()
    {
        if (_check.Check is null)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Account not loaded",
            };
        }

        _transactionRepository.AddTransaction(_check.Check.Number, "balance");
        return new CheckServiceResult.Success
        {
            Data = _check.Check.Balance,
        };
    }

    public CheckServiceResult TryWithdraw(decimal amount)
    {
        if (_check.Check is null)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Account not loaded",
            };
        }

        if (_check.Check.Balance < amount)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Not enough money on balance",
            };
        }

        _check.Check.Balance -= amount;

        _checkRepository.UpdateCheckMoney(_check.Check.Number, amount);

        _transactionRepository.AddTransaction(_check.Check.Number, "withdraw");

        return new CheckServiceResult.Success();
    }

    public CheckServiceResult TryDeposit(decimal amount)
    {
        if (_check.Check is null)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Account not loaded",
            };
        }

        _check.Check.Balance += amount;

        _checkRepository.UpdateCheckMoney(_check.Check.Number, amount);

        _transactionRepository.AddTransaction(_check.Check.Number, "deposit");

        return new CheckServiceResult.Success();
    }

    public CheckServiceResult CreateCheck(int number, int pin)
    {
        if (_checkRepository.FindCheckByNumber(number) != null)
        {
            return new CheckServiceResult.CheckServiceError
            {
                Message = $"Check number {number} is already exists",
            };
        }

        _checkRepository.CreateCheck(number, pin);

        _transactionRepository.AddTransaction(number, "create")
;
        return new CheckServiceResult.Success();
    }
}