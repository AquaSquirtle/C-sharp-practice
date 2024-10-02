using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Train(Force maxForce, Weight weight) : IBaseTrain
{
    private readonly Acceleration _acceleration = new Acceleration(0);

    public Speed Speed { get;  } = new Speed(0);

    public void ApplyForce(Force force)
    {
        if (maxForce.Value < force.Value)
        {
            throw new ArgumentException("Applied force cannot be less than the max force.");
        }

        _acceleration.Value = force.Value / weight.Value;
    }

    public void SpeedUp(double precision)
    {
        Speed.Value += _acceleration.Value * precision;
    }
}