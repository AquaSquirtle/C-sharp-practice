using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly FileSystemContext _fileSystem;

    public ConnectCommand(string path, FileSystemContext fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        ICommandValidator validator = new AbsolutePathValidator(_path)
            .SetNext(new DirectoryExistsValidator(_path));

        validator.Validate(_fileSystem);
        SettingsManager.Instance.SetSettingValue("CurrentFileSystemSetting", _fileSystem);
        SettingsManager.Instance.GetSettingValue<FileSystemContext>("CurrentFileSystemSetting").Connect(_path);
    }
}