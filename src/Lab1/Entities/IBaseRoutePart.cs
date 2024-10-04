using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IBaseRoutePart
{
    public Result Run(Train train, double precision);
}
