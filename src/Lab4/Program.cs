using Itmo.ObjectOrientedProgramming.Lab4.FileSystemFacades.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var facade = new CommonFileSystemFacade();
        while (true)
        {
            try
            {
                string argument = Console.ReadLine() ?? string.Empty;
                facade.TryExecuteCommand(argument);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}