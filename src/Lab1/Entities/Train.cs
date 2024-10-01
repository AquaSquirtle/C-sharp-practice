using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Train(Force maxForce, Weight weight) : BaseTrain
{
    private readonly Force _maxForce = maxForce;
    private readonly Weight _weight = weight;
    private readonly Acceleration _acceleration = new Acceleration(0);

    public Speed Speed { get;  } = new Speed(0);

    public override void ApplyForce(Force force)
    {
        if (_maxForce.Value < force.Value)
        {
            throw new ArgumentException("Applied force cannot be less than the max force.");
        }

        _acceleration.Value = force.Value / _weight.Value;
    }

    public override void SpeedUp(double precision)
    {
        Speed.Value += _acceleration.Value * precision;
    }
}