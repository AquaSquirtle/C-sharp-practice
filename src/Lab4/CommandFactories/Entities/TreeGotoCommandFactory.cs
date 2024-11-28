using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;

public class TreeGotoCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        var validator = new PositionalArgumentValidator(1);
        validator.Validate(flagArguments, positionalArguments);

        string path = positionalArguments.ElementAt(0);

        return new TreeGotoCommand(path);
    }
}