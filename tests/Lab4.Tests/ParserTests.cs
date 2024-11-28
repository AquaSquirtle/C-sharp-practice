using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Entities;
using Xunit;

namespace Lab4.Tests;

public class ParserTests
{
    private readonly CommandParser parser = new CommandParser([
        "connect",
        "disconnect",
        "tree goto",
        "tree list",
        "file show",
        "file move",
        "file copy",
        "file delete",
        "file rename"
    ]);

    [Theory]
    [InlineData(
        "connect / -m Local",
        "connect",
        "-m Local",
        "/")]

    [InlineData(
        "disconnect",
        "disconnect",
        "",
        "")]

    [InlineData(
        "tree goto /home",
        "tree goto",
        "",
        "/home")]

    [InlineData(
        "tree list -d 10",
        "tree list",
        "-d 10",
        "")]

    [InlineData(
        "file show /home/asd.txt -m Console",
        "file show",
        "-m Console",
        "/home/asd.txt")]

    [InlineData(
        "file move /home/asd.txt /home/test2",
        "file move",
        "",
        "/home/asd.txt /home/test2")]

    [InlineData(
        "file copy /home/asd.txt /home/test2",
        "file copy",
        "",
        "/home/asd.txt /home/test2")]

    [InlineData(
        "file delete /home/asd.txt",
        "file delete",
        "",
        "/home/asd.txt")]

    [InlineData(
        "file rename /home/asd.txt newName.txt",
        "file rename",
        "",
        "/home/asd.txt newName.txt")]
    public void CommandCreationTest(
        string parseArgument,
        string expectedCommandName,
        string expectedFlagArguments,
        string expectedPositionalArguments)
    {
        (string CommandKey,
            SortedDictionary<string, string> FlagArguments,
            ICollection<string> PositionalArguments) parseResult = parser.Parse(parseArgument);
        Assert.Equal(expectedCommandName, parseResult.CommandKey);
        Assert.Equal(expectedFlagArguments, string.Join(
            " ",
            parseResult.FlagArguments.Select(x => $"{x.Key} {x.Value}")));
        Assert.Equal(expectedPositionalArguments, string.Join(" ", parseResult.PositionalArguments));
    }
}