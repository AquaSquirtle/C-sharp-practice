using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MagneticForceRoute(Force force, Distance distance) : IBaseRoutePart
{
    public double Run(Train train, double precision)
    {
        double timeSpent = 0;
        double temp_distance = distance.Value;

        train.ApplyForce(force);

        while (temp_distance > 0)
        {
            train.SpeedUp(precision);
            if (train.Speed.Value <= 0)
            {
                throw new ArgumentException("Speed cannot be negative");
            }

            temp_distance -= train.Speed.Value * precision;
            ++timeSpent;
        }

        train.ApplyForce(new Force(0));
        return timeSpent;
    }
}