namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public interface IFileSystemState
{
    void Connect(FileSystemContext context, string path);

    void Disconnect(FileSystemContext context);

    string ReadFile(FileSystemContext context, string path);

    void MoveFile(FileSystemContext context, string sourcePath, string destinationPath);

    void CopyFile(FileSystemContext context, string sourcePath, string destinationPath);

    void DeleteFile(FileSystemContext context, string path);

    void RenameFile(FileSystemContext context, string path, string newName);

    void ChangeDirectory(FileSystemContext context, string path);

    IEnumerable<string> ListDirectory(FileSystemContext context, int depth = 1);
}