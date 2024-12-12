using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

public interface ICurrentCheckService
{
    Check? Check { get; }

    void CloseCheck();
}