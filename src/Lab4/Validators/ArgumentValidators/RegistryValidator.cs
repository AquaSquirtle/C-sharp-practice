using Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

public class RegistryValidator<T> : ArgumentValidator
{
    private readonly string _requiredMode;
    private readonly Registry<T> _modeRegistry;

    public RegistryValidator(string requiredMode, Registry<T> modeRegistry)
    {
        _requiredMode = requiredMode;
        _modeRegistry = modeRegistry;
    }

    protected override void PerformValidation(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        if (!flagArguments.ContainsKey(_requiredMode))
        {
            throw new ArgumentException($"flag named {_requiredMode} not found.");
        }

        if (!_modeRegistry.Contains(flagArguments[_requiredMode]))
        {
            string registeredModes = string.Join(", ", _modeRegistry.GetAllKeys());

            throw new ArgumentException($"Mode {flagArguments[_requiredMode]} not registered." +
                                        $"\nRegistered Modes: {registeredModes}");
        }
    }
}