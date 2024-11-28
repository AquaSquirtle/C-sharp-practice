using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;

public class FileShowCommandFactory : ICommandFactory
{
    private readonly Registry<IDisplay> _displayRegistry;

    public FileShowCommandFactory(Registry<IDisplay> displayRegistry)
    {
        _displayRegistry = displayRegistry;
    }

    public ICommand CreateCommand(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        IArgumentValidator validator = new PositionalArgumentValidator(1)
            .SetNext(new RegistryValidator<IDisplay>("-m", _displayRegistry));
        validator.Validate(flagArguments, positionalArguments);

        string path = positionalArguments.ElementAt(0);
        string modeKey = flagArguments["-m"];
        IDisplay display = _displayRegistry.Get(modeKey);

        return new FileShowCommand(path, display);
    }
}