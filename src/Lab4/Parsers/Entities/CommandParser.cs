namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.Entities;

public class CommandParser
{
    private readonly ICollection<string> _commandKeys;

    public CommandParser(ICollection<string> commandKeys)
    {
        _commandKeys = commandKeys;
    }

    public (
        string CommandKey,
        SortedDictionary<string, string> FlagArguments,
        ICollection<string> PositionalArguments)
        Parse(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = parts.Length; i > 0; i--)
        {
            string potentialKey = string.Join(" ", parts.Take(i));
            if (_commandKeys.Contains(potentialKey))
            {
                string[] args = parts.Skip(i).ToArray();

                (SortedDictionary<string, string> flagArguments,
                    ICollection<string> positionalArguments) = ParseArguments(args);

                return (potentialKey, flagArguments, positionalArguments);
            }
        }

        throw new ArgumentException("There is no such command");
    }

    private (SortedDictionary<string, string> FlagArguments,
        ICollection<string> PositionalArguments) ParseArguments(string[] args)
    {
        var flagArguments = new SortedDictionary<string, string>();
        var positionalArguments = new List<string>();

        for (int i = 0; i < args.Length; i++)
        {
            string token = args[i];
            if (token.StartsWith('-'))
            {
                if (i + 1 < args.Length && !args[i + 1].StartsWith('-'))
                {
                    flagArguments[token] = args[i + 1];
                    i++;
                }
                else
                {
                    flagArguments[token] = string.Empty;
                }
            }
            else
            {
                positionalArguments.Add(token);
            }
        }

        return (flagArguments, positionalArguments);
    }
}
