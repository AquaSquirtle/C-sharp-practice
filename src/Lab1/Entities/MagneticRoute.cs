using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MagneticRoute(Distance distance) : BaseRoutePart
{
    public Distance Distance { get; set; } = distance;

    public override void CheckTrainSpeed(Speed speed)
    {
        if (speed.Value <= 0)
        {
            throw new ArgumentException("Speed cannot be negative");
        }
    }
}