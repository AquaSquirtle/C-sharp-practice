namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public abstract class BaseFileSystemState : IFileSystemState
{
    public virtual void Connect(FileSystemContext context, string path)
    {
        throw new InvalidOperationException("Operation 'Connect' is not allowed in the current state.");
    }

    public virtual void Disconnect(FileSystemContext context)
    {
        throw new InvalidOperationException("Operation 'Disconnect' is not allowed in the current state.");
    }

    public virtual string ReadFile(FileSystemContext context, string path)
    {
        throw new InvalidOperationException("Operation 'ReadFile' is not allowed in the current state.");
    }

    public virtual void MoveFile(FileSystemContext context, string sourcePath, string destinationPath)
    {
        throw new InvalidOperationException("Operation 'MoveFile' is not allowed in the current state.");
    }

    public virtual void CopyFile(FileSystemContext context, string sourcePath, string destinationPath)
    {
        throw new InvalidOperationException("Operation 'CopyFile' is not allowed in the current state.");
    }

    public virtual void DeleteFile(FileSystemContext context, string path)
    {
        throw new InvalidOperationException("Operation 'DeleteFile' is not allowed in the current state.");
    }

    public virtual void RenameFile(FileSystemContext context, string path, string newName)
    {
        throw new InvalidOperationException("Operation 'RenameFile' is not allowed in the current state.");
    }

    public virtual void ChangeDirectory(FileSystemContext context, string path)
    {
        throw new InvalidOperationException("Operation 'TreeGoto' is not allowed in the current state.");
    }

    public virtual IEnumerable<string> ListDirectory(FileSystemContext context, int depth = 1)
    {
        throw new InvalidOperationException("Operation 'TreeList' is not allowed in the current state.");
    }
}
