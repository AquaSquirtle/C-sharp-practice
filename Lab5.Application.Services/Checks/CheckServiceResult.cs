namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

public abstract record CheckServiceResult
{
    private CheckServiceResult() { }

    public string Message { get; init; } = string.Empty;

    public object? Data { get; init; }

    public sealed record Success : CheckServiceResult;

    public sealed record CheckServiceError : CheckServiceResult;
}