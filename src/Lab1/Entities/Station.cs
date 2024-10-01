using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Station(Speed speedLimitModule, double workloadFactor) : BaseRoutePart
{
    public double WorkloadFactor { get; } = workloadFactor;

    public override void CheckTrainSpeed(Speed speed)
    {
        if (speedLimitModule.Value < speed.Value)
        {
            throw new ArgumentException("Speed must be less than speed limit of station.");
        }
    }
}