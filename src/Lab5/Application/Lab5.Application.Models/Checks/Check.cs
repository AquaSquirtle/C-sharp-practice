namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;

public class Check(int number, int pin, decimal amount)
{
    public int Number { get; } = number;

    public int Pin { get; } = pin;

    public decimal Balance { get; set; } = amount;
}