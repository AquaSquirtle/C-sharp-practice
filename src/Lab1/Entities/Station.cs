using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Station(Speed speedLimitModule, double workloadFactor) : IBaseRoutePart
{
    public Result Run(Train train, double precision)
    {
        return speedLimitModule.Value >= train.Speed.Value ? new Result.Success(workloadFactor) : new Result.StationSpeedLimit();
    }
}