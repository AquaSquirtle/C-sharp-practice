namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class LocalFileSystemAdapter : IFileSystem
{
    public string Key { get; } = "Local";

    private LocalFileSystem _fileSystem;

    public LocalFileSystemAdapter(LocalFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Connect(string path)
    {
        _fileSystem.SetRootPath(path);
    }

    public void Disconnect()
    {
        _fileSystem = new LocalFileSystem(string.Empty);
    }

    public string ReadFile(string path)
    {
        return _fileSystem.ReadFile(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        _fileSystem.DeleteFile(path);
    }

    public void RenameFile(string path, string newName)
    {
        _fileSystem.RenameFile(path, newName);
    }

    public void ChangeDirectory(string path)
    {
        _fileSystem.ChangeDirectory(path);
    }

    public IEnumerable<string> ListDirectory(int depth = 1)
    {
        return _fileSystem.ListDirectory(depth);
    }

    public bool FileExists(string path)
    {
        return _fileSystem.FileExists(path);
    }

    public bool DirectoryExists(string path)
    {
        return _fileSystem.DirectoryExists(path);
    }

    public bool IsAbsolutePath(string path)
    {
        return _fileSystem.IsAbsolutePath(path);
    }
}
