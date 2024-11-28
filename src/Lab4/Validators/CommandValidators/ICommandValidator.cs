using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

public interface ICommandValidator
{
    void Validate(FileSystemContext fileSystem);

    ICommandValidator SetNext(ICommandValidator nextValidator);
}
