using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

public class CurrentFileSystemSetting : ISetting<FileSystemContext>
{
    public string Key { get; } = "CurrentFileSystemSetting";

    private FileSystemContext? _value;

    public FileSystemContext GetValue()
    {
        if (_value == null)
        {
            throw new InvalidOperationException($"Current setting '{Key}' have not been initialized yet.");
        }

        return _value;
    }

    public void Update(FileSystemContext value)
    {
        _value = value;
    }
}