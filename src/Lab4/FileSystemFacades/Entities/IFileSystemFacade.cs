namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemFacades.Entities;

public interface IFileSystemFacade
{
    public void TryExecuteCommand(string textCommand);
}