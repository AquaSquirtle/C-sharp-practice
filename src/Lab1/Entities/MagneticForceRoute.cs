using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MagneticForceRoute(Force force, Distance distance) : IBaseRoutePart
{
    public Result Run(Train train, double precision)
    {
        double timeSpent = 0;
        double tempDistance = distance.Value;

        train.TryApplyForce(force);

        while (tempDistance > 0)
        {
            train.SpeedUp(precision);
            if (train.Speed.Value <= 0)
            {
                return new Result.NegativeSpeed();
            }

            tempDistance -= train.Speed.Value * precision;
            ++timeSpent;
        }

        train.TryApplyForce(new Force(0));
        return new Result.Success(timeSpent);
    }
}