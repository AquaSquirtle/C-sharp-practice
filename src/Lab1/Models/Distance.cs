namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Distance
{
    private double _distance;

    public Distance(double distance)
    {
        if (distance < 0) throw new ArgumentException("Distance must be greater than zero");
        _distance = distance;
    }

    public double Value
    {
        get => _distance;
        set => _distance = value < 0 ? throw new ArgumentException("Distance must be greater than zero") : value;
    }
}