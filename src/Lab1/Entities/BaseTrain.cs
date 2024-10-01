using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseTrain
{
    public abstract void SpeedUp(double precision);

    public abstract void ApplyForce(Force force);
}