namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public interface IFileSystem
{
    void Connect(string path);

    void Disconnect();

    string ReadFile(string path);

    void MoveFile(string sourcePath, string destinationPath);

    void CopyFile(string sourcePath, string destinationPath);

    void DeleteFile(string path);

    void RenameFile(string path, string newName);

    void ChangeDirectory(string path);

    IEnumerable<string> ListDirectory(int depth);

    bool DirectoryExists(string path);

    bool FileExists(string path);

    bool IsAbsolutePath(string path);
}