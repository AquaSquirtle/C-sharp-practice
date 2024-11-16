namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger(string path)
    {
        _path = path;
    }

    public void Log(string message)
    {
        File.WriteAllText(_path, message);
    }
}