using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Station(Speed speedLimitModule, double workloadFactor) : IBaseRoutePart
{
    public double Run(Train train, double precision)
    {
        return speedLimitModule.Value >= train.Speed.Value ? workloadFactor : throw new ArgumentException("Speed must be less than speed limit of station.");
    }
}