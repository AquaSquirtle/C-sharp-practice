using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

public class AbsolutePathValidator : CommandValidator
{
    private readonly string _path;

    public AbsolutePathValidator(string path)
    {
        _path = path;
    }

    protected override void PerformValidation(FileSystemContext fileSystem)
    {
        if (!fileSystem.FileSystem.IsAbsolutePath(_path))
        {
            throw new FileNotFoundException($"File '{_path}' does not exist.");
        }
    }
}