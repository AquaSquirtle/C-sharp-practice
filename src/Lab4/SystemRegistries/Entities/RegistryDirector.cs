using Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;

public static class RegistryDirector
{
    public static Registry<ICommandFactory> CreateCommandRegistry(
        Registry<FileSystemContext> connectModeRegistry,
        Registry<IDisplay> displayModeRegistry)
    {
        var builder = new Registry<ICommandFactory>.RegistryBuilder();

        builder
            .Add("connect", new ConnectCommandFactory(connectModeRegistry))
            .Add("disconnect", new DisconnectCommandFactory())
            .Add("file copy", new FileCopyCommandFactory())
            .Add("file move", new FileMoveCommandFactory())
            .Add("file delete", new FileDeleteCommandFactory())
            .Add("file rename", new FileRenameCommandFactory())
            .Add("file show", new FileShowCommandFactory(displayModeRegistry))
            .Add("tree goto", new TreeGotoCommandFactory())
            .Add("tree list", new TreeListCommandFactory());

        return builder.Build();
    }

    public static Registry<FileSystemContext> CreateConnectModeRegistry()
    {
        var builder = new Registry<FileSystemContext>.RegistryBuilder();
        builder.Add("Local", new FileSystemContext(new LocalFileSystemAdapter(new LocalFileSystem(string.Empty)), "Local"));

        return builder.Build();
    }

    public static Registry<IDisplay> CreateDisplayModeRegistry()
    {
        var builder = new Registry<IDisplay>.RegistryBuilder();
        builder.Add("Console", new ConsoleDisplayAdapter(new ConsoleDisplay()));
        return builder.Build();
    }
}