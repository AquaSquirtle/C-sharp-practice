using Itmo.ObjectOrientedProgramming.Lab1.Models;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route(ReadOnlyCollection<IBaseRoutePart> routeParts, Speed forceModule)
{
    public ReadOnlyCollection<IBaseRoutePart> RouteParts { get; } = routeParts;

    public Speed ForceModule { get; } = forceModule;
}