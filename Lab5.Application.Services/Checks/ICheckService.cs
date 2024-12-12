namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

public interface ICheckService
{
    CheckServiceResult LoadCheck(int number, int pin);

    CheckServiceResult GetBalance();

    CheckServiceResult TryWithdraw(decimal amount);

    CheckServiceResult TryDeposit(decimal amount);

    CheckServiceResult CreateCheck(int number, int pin);
}