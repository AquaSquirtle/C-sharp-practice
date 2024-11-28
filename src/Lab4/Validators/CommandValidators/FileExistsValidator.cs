using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

public class FileExistsValidator : CommandValidator
{
    private readonly string _path;

    public FileExistsValidator(string path)
    {
        _path = path;
    }

    protected override void PerformValidation(FileSystemContext fileSystem)
    {
        if (!fileSystem.FileSystem.FileExists(_path))
        {
            throw new FileNotFoundException($"File '{_path}' does not exist.");
        }
    }
}