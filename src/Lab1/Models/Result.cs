namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract record Result
{
    private Result() { }

    public sealed record Success(double Time) : Result;

    public sealed record NegativeSpeed : Result;

    public sealed record StationSpeedLimit : Result;

    public sealed record RouteForceModuleLimit : Result;
}