using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface ICheckRepository
{
    Check? FindCheckByNumber(int number);

    void CreateCheck(int number, int pin);

    void UpdateCheckMoney(int checkNumber, decimal money);
}