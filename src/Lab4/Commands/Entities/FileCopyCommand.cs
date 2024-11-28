using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileCopyCommand : ICommand
{
    private readonly string _destination;
    private readonly string _source;
    private readonly string _destinationPath;

    public FileCopyCommand(string source, string destination)
    {
        _source = source;
        _destination = destination;
        _destinationPath = Path.Combine(_destination, Path.GetFileName(source));
    }

    public void Execute()
    {
        FileSystemContext fileSystemContext = SettingsManager
            .Instance
            .GetSettingValue<FileSystemContext>("CurrentFileSystemSetting");

        ICommandValidator validator = new FileExistsValidator(_source)
            .SetNext(new DirectoryExistsValidator(_destination))
            .SetNext(new FileNotExistsValidator(_destinationPath));

        validator.Validate(fileSystemContext);

        fileSystemContext.CopyFile(_source, _destinationPath);
    }
}