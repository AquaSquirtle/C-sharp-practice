using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Train(Force maxForce, Weight weight) : IBaseTrain
{
    private readonly Acceleration _acceleration = new Acceleration(0);

    public Speed Speed { get;  } = new Speed(0);

    public void TryApplyForce(Force force)
    {
        if (double.Abs(maxForce.Value) < double.Abs(force.Value))
        {
            return;
        }

        _acceleration.Value = force.Value / weight.Value;
    }

    public void SpeedUp(double precision)
    {
        Speed.Value += _acceleration.Value * precision;
    }
}