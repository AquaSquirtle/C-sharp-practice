using Itmo.ObjectOrientedProgramming.Lab4.CommandFactories.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.CommandInvokers.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Display.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemFacades.Entities;

public class CommonFileSystemFacade : IFileSystemFacade
{
    private readonly CommandParser _parser;
    private readonly ICommandInvoker _commandInvoker;
    private readonly Registry<ICommandFactory> _commandFactoryRegistry;

    public CommonFileSystemFacade(
        ICommandInvoker commandInvoker,
        Registry<ICommandFactory> commandFactoryRegistry,
        CommandParser parser)
    {
        _parser = parser;
        _commandInvoker = commandInvoker;
        _commandFactoryRegistry = commandFactoryRegistry;
    }

    public CommonFileSystemFacade()
    {
        Registry<FileSystemContext> rg = RegistryDirector.CreateConnectModeRegistry();
        Registry<IDisplay> dp = RegistryDirector.CreateDisplayModeRegistry();
        Registry<ICommandFactory> factories = RegistryDirector.CreateCommandRegistry(rg, dp);
        SettingsManager.Instance.RegisterSetting(new CurrentFileSystemSetting());
        SettingsManager.Instance.RegisterSetting(new CurrentDisplaySetting());
        _parser = new CommandParser(factories.GetAllKeys());
        _commandInvoker = new CommandInvoker();
        _commandFactoryRegistry = factories;
    }

    public void TryExecuteCommand(string textCommand)
    {
        (string commandKey,
            SortedDictionary<string, string> flagArguments,
            ICollection<string> positionalArguments) = _parser.Parse(textCommand);

        ICommand command = _commandFactoryRegistry.Get(commandKey).CreateCommand(flagArguments, positionalArguments);
        _commandInvoker.SetCommand(command);
        _commandInvoker.TryInvoke();
    }
}