using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MagneticRoute(Distance distance) : IBaseRoutePart
{
    public double Run(Train train, double precision)
    {
        double timeSpent = 0;
        if (train.Speed.Value <= 0)
        {
            throw new ArgumentException("Speed cannot be negative");
        }

        double tempDistance = distance.Value;
        while (tempDistance > 0)
        {
            tempDistance -= train.Speed.Value * precision;
            ++timeSpent;
        }

        return timeSpent;
    }
}