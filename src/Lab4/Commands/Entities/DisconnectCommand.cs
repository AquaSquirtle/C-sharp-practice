using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class DisconnectCommand : ICommand
{
    public void Execute()
    {
        SettingsManager.Instance.GetSettingValue<FileSystemContext>("CurrentFileSystemSetting").Disconnect();
    }
}