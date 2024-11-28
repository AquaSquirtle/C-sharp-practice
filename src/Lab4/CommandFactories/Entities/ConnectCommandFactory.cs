using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;

public class ConnectCommandFactory : ICommandFactory
{
    private readonly Registry<FileSystemContext> _fileSystemRegistry;

    public ConnectCommandFactory(Registry<FileSystemContext> fileSystemRegistry)
    {
        _fileSystemRegistry = fileSystemRegistry;
    }

    public ICommand CreateCommand(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        IArgumentValidator validator = new PositionalArgumentValidator(1)
            .SetNext(new RegistryValidator<FileSystemContext>("-m", _fileSystemRegistry));
        validator.Validate(flagArguments, positionalArguments);

        string path = positionalArguments.ElementAt(0);
        string modeKey = flagArguments["-m"];
        FileSystemContext fileSystem = _fileSystemRegistry.Get(modeKey);

        return new ConnectCommand(path, fileSystem);
    }
}
