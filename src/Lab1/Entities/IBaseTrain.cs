using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IBaseTrain
{
    public void SpeedUp(double precision);

    public void ApplyForce(Force force);
}