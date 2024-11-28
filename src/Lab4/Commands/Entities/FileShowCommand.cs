using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly IDisplay _display;

    public FileShowCommand(string path, IDisplay display)
    {
        _path = path;
        _display = display;
    }

    public void Execute()
    {
        FileSystemContext fileSystemContext = SettingsManager
            .Instance
            .GetSettingValue<FileSystemContext>("CurrentFileSystemSetting");

        SettingsManager
                .Instance
                .SetSettingValue("CurrentDisplaySetting", _display);

        var validator = new FileExistsValidator(_path);
        validator.Validate(fileSystemContext);

        _display.Display(fileSystemContext.ReadFile(_path));
    }
}