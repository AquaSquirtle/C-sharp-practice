using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;

public class FileMoveCommandFactory : ICommandFactory
{
    public ICommand CreateCommand(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        var validator = new PositionalArgumentValidator(2);
        validator.Validate(flagArguments, positionalArguments);

        string source = positionalArguments.ElementAt(0);
        string destination = positionalArguments.ElementAt(1);

        return new FileMoveCommand(source, destination);
    }
}