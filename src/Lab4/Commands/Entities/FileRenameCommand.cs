using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        FileSystemContext fileSystemContext = SettingsManager
            .Instance
            .GetSettingValue<FileSystemContext>("CurrentFileSystemSetting");
        if (Path.GetFileName(_path) != _newName)
        {
            var validator = new FileNotExistsValidator(Path.Combine(Path.GetDirectoryName(_path) ?? string.Empty, _newName));
            validator.Validate(fileSystemContext);
        }

        fileSystemContext.RenameFile(_path, _newName);
    }
}
