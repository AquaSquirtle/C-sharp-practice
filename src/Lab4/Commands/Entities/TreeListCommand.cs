using Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreePrinters.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth = 1)
    {
        _depth = depth;
    }

    public void Execute()
    {
        FileSystemContext fileSystemContext = SettingsManager
            .Instance
            .GetSettingValue<FileSystemContext>("CurrentFileSystemSetting");

        var formatter = new DirectoryTreeFormatter();
        foreach (string path in fileSystemContext.ListDirectory(_depth))
        {
            Console.WriteLine(path);
        }

        string result = formatter.FormatTree(fileSystemContext.ListDirectory(_depth));
        SettingsManager.Instance.GetSettingValue<IDisplay>("CurrentDisplaySetting").Display(result);
    }
}