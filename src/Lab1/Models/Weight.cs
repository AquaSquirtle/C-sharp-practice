namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Weight(double weight)
{
    private double _weight = weight > 0 ? weight : throw new ArgumentException("Weight cant be negative");

    public double Value
    {
        get => _weight;
        set => _weight = value < 0 ? throw new ArgumentException("Weight cant be negative") : value;
    }
}