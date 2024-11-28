namespace Itmo.ObjectOrientedProgramming.Lab4.DirectoryTreePrinters.Entities;

public class DirectoryTreeFormatter
{
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;
    private readonly string _indent;

    public DirectoryTreeFormatter(string folderSymbol = "📁 ", string fileSymbol = "📄 ", string indent = "  ")
    {
        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
        _indent = indent;
    }

    public string FormatTree(IEnumerable<string> paths)
    {
        var sortedPaths = paths.OrderBy(p => p).ToList();
        return FormatPaths(sortedPaths);
    }

    private string FormatPaths(List<string> paths)
    {
        var result = new List<string>();
        string previousPath = string.Empty;

        foreach (string path in paths)
        {
            string[] parts = path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string[] previousParts = previousPath.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            int depth = parts.Length - 1;

            bool isFile = !paths.Any(p => p.StartsWith(path + Path.DirectorySeparatorChar));

            string name = parts.Last();

            string symbol = isFile ? _fileSymbol : _folderSymbol;
            result.Add($"{Repeat(depth)}{symbol}{name}");

            previousPath = path;
        }

        return string.Join('\n', result);
    }

    private string Repeat(int count)
    {
        return new string(' ', count * _indent.Length);
    }
}
