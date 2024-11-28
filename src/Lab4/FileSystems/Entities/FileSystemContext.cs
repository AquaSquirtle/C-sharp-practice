namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class FileSystemContext
{
    public string Key { get; }

    private IFileSystemState _currentState;

    public IFileSystem FileSystem { get; private set; }

    public FileSystemContext(IFileSystem fileSystem, string key)
    {
        Key = key;
        FileSystem = fileSystem;
        _currentState = new DisconnectedFileSystemState();
    }

    public void SetState(IFileSystemState state)
    {
        _currentState = state;
    }

    public void Connect(string path)
    {
        _currentState.Connect(this, path);
    }

    public void Disconnect()
    {
        _currentState.Disconnect(this);
    }

    public string ReadFile(string path)
    {
        return _currentState.ReadFile(this, path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        _currentState.MoveFile(this, sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        _currentState.CopyFile(this, sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        _currentState.DeleteFile(this, path);
    }

    public void RenameFile(string path, string newName)
    {
        _currentState.RenameFile(this, path, newName);
    }

    public void ChangeDirectory(string path)
    {
        _currentState.ChangeDirectory(this, path);
    }

    public IEnumerable<string> ListDirectory(int depth = 1)
    {
        return _currentState.ListDirectory(this, depth);
    }
}
