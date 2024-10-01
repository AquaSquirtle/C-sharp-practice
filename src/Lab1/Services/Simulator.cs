using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Simulator(Route route, Train train, double precision)
{
    private double timeSpent;

    public double FollowTheRoute()
    {
        foreach (BaseRoutePart routePart in route.RouteParts)
        {
            switch (routePart)
            {
                case Station station:
                {
                    StationCase(station);
                    break;
                }

                case MagneticRoute magneticRoute:
                {
                    MagneticRouteCase(magneticRoute);
                    break;
                }

                case MagneticForceRoute magneticForceRoute:
                {
                    MagneticForceRouteCase(magneticForceRoute);
                    break;
                }

                default:
                    throw new InvalidOperationException("Unknown route");
            }
        }

        route.ForceModuleCheck(train.Speed);
        return timeSpent;
    }

    private void StationCase(Station station)
    {
        station.CheckTrainSpeed(train.Speed);
        timeSpent += station.WorkloadFactor;
    }

    private void MagneticRouteCase(MagneticRoute magneticRoute)
    {
        magneticRoute.CheckTrainSpeed(train.Speed);
        double distance = magneticRoute.Distance.Value;
        while (distance > 0)
        {
            distance -= train.Speed.Value * precision;
            ++timeSpent;
        }
    }

    private void MagneticForceRouteCase(MagneticForceRoute magneticForceRoute)
    {
        double distance = magneticForceRoute.Distance.Value;

        train.ApplyForce(magneticForceRoute.Force);

        while (distance > 0)
        {
            train.SpeedUp(precision);
            magneticForceRoute.CheckTrainSpeed(train.Speed);
            distance -= train.Speed.Value * precision;
            ++timeSpent;
        }

        train.ApplyForce(new Force(0));
    }
}