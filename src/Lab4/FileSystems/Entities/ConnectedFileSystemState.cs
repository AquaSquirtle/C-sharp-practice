namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class ConnectedFileSystemState : BaseFileSystemState
{
    public override void Connect(FileSystemContext context, string path)
    {
        throw new InvalidOperationException($"File system {context.Key} is already connected.");
    }

    public override void Disconnect(FileSystemContext context)
    {
        context.FileSystem.Disconnect();
        context.SetState(new DisconnectedFileSystemState());
    }

    public override string ReadFile(FileSystemContext context, string path)
    {
        return context.FileSystem.ReadFile(path);
    }

    public override void MoveFile(FileSystemContext context, string sourcePath, string destinationPath)
    {
        context.FileSystem.MoveFile(sourcePath, destinationPath);
    }

    public override void CopyFile(FileSystemContext context, string sourcePath, string destinationPath)
    {
        context.FileSystem.CopyFile(sourcePath, destinationPath);
    }

    public override void DeleteFile(FileSystemContext context, string path)
    {
        context.FileSystem.DeleteFile(path);
    }

    public override void RenameFile(FileSystemContext context, string path, string newName)
    {
        context.FileSystem.RenameFile(path, newName);
    }

    public override void ChangeDirectory(FileSystemContext context, string path)
    {
        context.FileSystem.ChangeDirectory(path);
    }

    public override IEnumerable<string> ListDirectory(FileSystemContext context, int depth = 1)
    {
        return context.FileSystem.ListDirectory(depth);
    }
}
