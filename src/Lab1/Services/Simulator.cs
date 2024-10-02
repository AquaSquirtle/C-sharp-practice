using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Simulator(Route route, Train train, double precision)
{
    private double timeSpent;

    public double FollowTheRoute()
    {
        foreach (IBaseRoutePart routePart in route.RouteParts)
        {
            timeSpent += routePart.Run(train, precision);
        }

        route.ForceModuleCheck(train.Speed);
        return timeSpent;
    }
}