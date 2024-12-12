using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Checks;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services.Checks;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Checks;

public class CurrentCheckService : ICurrentCheckService
{
    public Check? Check { get; set; }

    public void CloseCheck()
    {
        Check = null;
    }
}