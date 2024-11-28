namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

public class LocalFileSystem
{
    public string RootPath { get; private set; }

    public string CurrentPath { get; private set; }

    public LocalFileSystem(string rootPath)
    {
        RootPath = rootPath;
        CurrentPath = RootPath;
    }

    public void SetRootPath(string newRootPath)
    {
        RootPath = Path.GetFullPath(newRootPath);

        if (!CurrentPath.StartsWith(RootPath, StringComparison.Ordinal))
        {
            CurrentPath = RootPath;
        }
    }

    public void ChangeDirectory(string relativeOrAbsolutePath)
    {
        string newPath = ResolvePath(relativeOrAbsolutePath);

        CurrentPath = newPath;
    }

    public IEnumerable<string> ListDirectory(int depth = 1)
    {
        List<string> result = EnumerateDirectory(CurrentPath, depth);
        result.Add(ResolvePath(CurrentPath));
        return result;
    }

    public string ReadFile(string filePath)
    {
        string absolutePath = ResolvePath(filePath);

        return File.ReadAllText(absolutePath);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        string absoluteSourcePath = ResolvePath(sourcePath);
        string absoluteDestinationPath = ResolvePath(destinationPath);

        File.Move(absoluteSourcePath, absoluteDestinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        string absoluteSourcePath = ResolvePath(sourcePath);
        string absoluteDestinationPath = ResolvePath(destinationPath);

        File.Copy(absoluteSourcePath, absoluteDestinationPath);
    }

    public void DeleteFile(string filePath)
    {
        string absolutePath = ResolvePath(filePath);

        File.Delete(absolutePath);
    }

    public void RenameFile(string filePath, string newName)
    {
        string absolutePath = ResolvePath(filePath);

        string newPath = ResolvePath(Path.Combine(Path.GetDirectoryName(filePath) ?? string.Empty, newName));

        File.Move(absolutePath, newPath);
    }

    public bool DirectoryExists(string dirPath)
    {
        return Directory.Exists(ResolvePath(dirPath));
    }

    public bool IsAbsolutePath(string absolutePath)
    {
        return Path.IsPathFullyQualified(absolutePath);
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(ResolvePath(filePath));
    }

    private string ResolvePath(string relativeOrAbsolutePath)
    {
        string fullPath = Path.IsPathFullyQualified(relativeOrAbsolutePath)
            ? Path.GetFullPath(relativeOrAbsolutePath)
            : Path.GetFullPath(Path.Combine(CurrentPath, relativeOrAbsolutePath));
        return fullPath;
    }

    private List<string> EnumerateDirectory(string path, int depth)
    {
        var entries = new List<string>();

        if (depth <= 0 || !HasAccessToDirectory(path))
        {
            return entries;
        }

        var directories = new List<string>();
        var files = new List<string>();

        foreach (string entry in Directory.EnumerateFileSystemEntries(path))
        {
            if (!entry.StartsWith(RootPath, StringComparison.Ordinal))
            {
                continue;
            }

            if (Directory.Exists(entry))
            {
                directories.Add(entry);
            }
            else
            {
                files.Add(entry);
            }
        }

        entries.AddRange(directories.Select(ResolvePath));
        entries.AddRange(files.Select(ResolvePath));

        foreach (string directory in directories)
        {
            entries.AddRange(EnumerateDirectory(directory, depth - 1));
        }

        return entries;
    }

    private bool HasAccessToDirectory(string path)
    {
        try
        {
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
