namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Admins;

public abstract record AdminServiceResult
{
    private AdminServiceResult() { }

    public sealed record Success : AdminServiceResult;

    public sealed record WrongPassword : AdminServiceResult;
}