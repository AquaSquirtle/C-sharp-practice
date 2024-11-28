using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute()
    {
        FileSystemContext fileSystemContext = SettingsManager
            .Instance
            .GetSettingValue<FileSystemContext>("CurrentFileSystemSetting");

        var validator = new FileExistsValidator(_path);
        validator.Validate(fileSystemContext);

        fileSystemContext.DeleteFile(_path);
    }
}