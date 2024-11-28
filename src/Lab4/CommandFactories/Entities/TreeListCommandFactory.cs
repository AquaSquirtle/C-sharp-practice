using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;

public class TreeListCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        var validator = new ModeArgumentValidator("-d");
        validator.Validate(flagArguments, positionalArguments);

        int depth = int.Parse(flagArguments["-d"]);

        return new TreeListCommand(depth);
    }
}