using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Simulator(Route route, Train train, double precision)
{
    private double timeSpent;

    public Result FollowTheRoute()
    {
        foreach (IBaseRoutePart routePart in route.RouteParts)
        {
            Result result = routePart.Run(train, precision);
            if (result is Result.Success success)
            {
                timeSpent += success.Time;
            }
            else
            {
                return result;
            }
        }

        return route.ForceModule.Value >= train.Speed.Value ? new Result.Success(timeSpent) : new Result.RouteForceModuleLimit();
    }
}