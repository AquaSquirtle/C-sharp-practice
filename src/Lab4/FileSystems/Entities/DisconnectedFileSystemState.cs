namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class DisconnectedFileSystemState : BaseFileSystemState
{
    public override void Connect(FileSystemContext context, string path)
    {
        context.FileSystem.Connect(path);
        context.SetState(new ConnectedFileSystemState());
    }

    public override void Disconnect(FileSystemContext context)
    {
        throw new InvalidOperationException($"File system is already disconnected.");
    }
}
